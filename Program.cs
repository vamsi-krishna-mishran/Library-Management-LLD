namespace library_management;

class Program
{
    static void Main(string[] args)
    {
        LibraryManagement instance=LibraryManagement.getInstance();

        instance.CreateLibrary(5);
        Book book=instance.AddBook(1,"WINGS OF FIRE","APJ ABDUL KALAM");
        BookCopy? copy=instance.AddBookCopy(2,book.Id,"PUBLISH INDIA");

        User user1=instance.AddUser("Vamsi Krishna");

        Borrow? borrow=instance.BorrowBook(copy?.Id??-1,user1.Id,-5);
        instance.ReturnBook(copy.Id);

    }
}
