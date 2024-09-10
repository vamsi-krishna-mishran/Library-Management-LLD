

/// <summary>
/// This Provides the CRUD for Books.
/// </summary>
public class BookService:BaseService{

     public Book AddBook(Book book){


        _repo.Books.Add(book.Id,book);
        return book;
     }

     public Book GetBook(int id){
        return _repo.Books[id];
     }


     public Book RemoveBook(Book book){
        _repo.Books.Remove(book.Id);
        return book;
     }
    
}