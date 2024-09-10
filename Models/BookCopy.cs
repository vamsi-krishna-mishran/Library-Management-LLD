
public class BookCopy{

    public int Id { get; set; }

    public Book Book { get; set; }=null!;

    public Rack Rack { get; set; }=null!;

    public string Publishers{ get; set; }=null!;

    public DateTime PublishedDate { get; set;} 

    public BookStatus status{ get; set; }=BookStatus.AVAILABLE;
}