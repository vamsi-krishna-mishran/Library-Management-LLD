

public class BookCopyService:BaseService{

    public BookCopy AddBook(BookCopy book){
        _repo.BookCopies.Add(book.Id,book);
        return book;
     }
    public BookCopy? GetBook(int id){
        return _repo.BookCopies.Values.Where(copy=>copy.Id == id).FirstOrDefault();
    }
     public BookCopy RemoveBook(int bookId){
        var result=_repo.BookCopies[bookId];
        _repo.BookCopies.Remove(bookId);
        return result;
     }
}