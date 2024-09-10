

/// <summary>
/// Library Management is the singleton entry point or orchestrator
/// to the entire library management system.
/// all the use cases are written inside this entrypoint
/// with specified parameters from the requirements.
/// It will be having instances for all the services 
/// that are part of the system and input validation and 
/// converting input data into required objects is converted here itself.
/// </summary>
public class LibraryManagement{

    private static LibraryManagement _instance=null!;

    
    public static LibraryManagement getInstance(){
        if(_instance==null){
            _instance = new LibraryManagement();
        }
        return _instance;
    }
    private readonly BookCopyService _bookCopyservice;
    private readonly BookService _bookService;

    private readonly UserService _userService;

    private readonly BorrowService _borrowService;

    private readonly LibraryService _libraryService;

    private readonly SearchService _searchService;

    private readonly IdGenerator _idGenerator;
    private readonly RackService _rackService;

    private readonly PaymentService _paymentService;

    private LibraryManagement(){
        _bookCopyservice = new BookCopyService();
        _bookService = new BookService();
        _borrowService = new BorrowService();
        _libraryService = new LibraryService();
        _searchService=new SearchService();
        _idGenerator=new IdGenerator();
        _rackService=new RackService();
        _userService=new UserService();
        _paymentService=new PaymentService();
    }


    public Library CreateLibrary(int rackCount){
        Library lib=new Library(){Id=_idGenerator.GenerateId()};
        lib.LibraryName=$"LIBRARY {lib.Id}";
        _libraryService.AddLibrary(lib);


        for(int i=0;i<rackCount;i++){
            Rack rack=new Rack(){Id=_idGenerator.GenerateId(),Library=lib};
            _rackService.AddRack(rack);
        }
        
        return lib;

    }

    public User AddUser(string name){
        User user=new User();
        user.Id=_idGenerator.GenerateId();
        user.Name=name;
        user.AddressId=_idGenerator.GenerateId();
        _userService.AddUser(user);
        return user;
    }

    public Book AddBook(int id,string title,string author){
        ///
        /// Orchestrator or Application Layer
        ///
        
        Book book=new Book();
        book.Id=id;
        
        book.Name=title;
        book.AuthorName=author;
        book.DateOfRelease=DateTime.UtcNow;
        _bookService.AddBook(book);
        return book;
    }

    public BookCopy? AddBookCopy(int id,int BookId,string publishers){
        Rack? freeRack=_rackService.GetFreeRack(BookId);
        Book? book=_bookService.GetBook(BookId);
        if(freeRack is null || book is null){
            Console.WriteLine("NO FREE RACK AVAILABLE>>");
            return null;
        }
        BookCopy copy=new BookCopy();
        copy.Book=book;
        copy.Id=id;
        copy.Publishers=publishers;
        copy.Rack=freeRack;
        copy.status=BookStatus.AVAILABLE;
        _bookCopyservice.AddBook(copy);
        return copy;

    }
    public BookCopy RemoveBookCopy(int copyId){
        BookCopy result=_bookCopyservice.RemoveBook(copyId);
        return result;
    }


    public Borrow? BorrowBook(int bookCopyId,int userId,int days){
        Borrow borrow=new Borrow();
        BookCopy? copy=_bookCopyservice.GetBook(bookCopyId);
        User? user=_userService.GetUser(userId);
        if(user is null || copy is null){
            Console.WriteLine("INVALID USER AND BOOKCOPY");
            return null;
        }
        if(copy.status==BookStatus.LENT){
            Console.WriteLine("BOOK COPY IS ALREADY LENT TO X");
            return null;
        }
        copy.status=BookStatus.LENT;
        borrow.Id=_idGenerator.GenerateId();
        borrow.BookCopy=copy;
        borrow.User=user;
        borrow.IssuedDate=DateTime.UtcNow;
        borrow.ReturnDate=DateTime.UtcNow.AddDays(days);
        
        _borrowService.AddBorrow(borrow);
        return borrow;
    }

    public List<int>? AllBorrows(int userId){
        List<int>? borrows=_borrowService.GetBorrowCopyIds(userId);
        return borrows;
    }

    public List<BookCopy>? Search(string type,string query){
        if(type=="Id"){
            return _searchService.SearchById(Convert.ToInt32(query));

        }
        else if(type=="Title"){
            return _searchService.SearchByTitle(query);
        }
        else if(type=="Author"){
            return _searchService.SearchByAuthor(query);
        }
        else if(type=="Publisher"){
            return _searchService.SearchByPublisher(query);
        }
        return null;
    }

    public BookCopy? ReturnBook(int copyId){
        Borrow? borrow=_borrowService.GetBorrow(copyId);
        DateTime now=DateTime.UtcNow;
        if(borrow is null){
            Console.WriteLine("THAT GIVEN COPY IS NOT LENT TO ANYONE.");
            return null;
        }
        TimeSpan diff=now-borrow.ReturnDate;
        int totalDueMinutes=(int)diff.TotalMinutes;
        if(totalDueMinutes>0){
            //extra time taken.
            Console.WriteLine("DUE EXCEEDED. SO GOING TO PAYMENT.");
            int amount=_paymentService.CalculatePayment(totalDueMinutes);
            Console.WriteLine($"DUE {amount} IS PROCESSED SUCCESSFULLY.");
            

        }
        borrow.BookCopy.status=BookStatus.AVAILABLE;
        return borrow.BookCopy;
    }

}