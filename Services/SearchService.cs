

/// <summary>
/// Search Service provides searches based on.
/// Id of book copy.
/// Name of book.
/// Author of book.
/// Publisher of the bookcopy.
/// </summary>
public class SearchService:BaseService{

       /// <summary>
       /// searching book copies by its Id.
       /// </summary>
       /// <param name="Id"></param>
       /// <returns></returns>
       public List<BookCopy> SearchById(int Id){
            List<BookCopy> books = new List<BookCopy>();
        
            if(_repo.BookCopies.ContainsKey(Id)){
                 books.Add(_repo.BookCopies[Id]);
            }
            return books;
       }

      /// <summary>
      /// searches the book copies by the title of the book it 
      /// belongs to.
      /// </summary>
      /// <param name="Title"></param>
      /// <returns>List of BookCopy</returns>
       public List<BookCopy> SearchByTitle(string Title){
            List<BookCopy> books=new List<BookCopy>();

            books=_repo.BookCopies.Values.Where(copy=>copy.Book.Name.Contains(Title)).ToList();
            return books;
       }

        /// <summary>
        /// returns the book copies based on the author.
        /// </summary>
        /// <param name="Author"></param>
        /// <returns></returns>
        public List<BookCopy> SearchByAuthor(string Author){
            List<BookCopy> books=new List<BookCopy>();

            books=_repo.BookCopies.Values.Where(copy=>copy.Book.AuthorName.Contains(Author)).ToList();
            return books;
       }


        /// <summary>
        /// returns bookcopies based on the publishers.
        /// </summary>
        /// <param name="Publisher"></param>
        /// <returns></returns>
       public List<BookCopy> SearchByPublisher(string Publisher){
            List<BookCopy> books=new List<BookCopy>();

            books=_repo.BookCopies.Values.Where(copy=>copy.Publishers.Contains(Publisher)).ToList();
            return books;
       }


}