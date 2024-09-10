
public class Borrow{

    public int Id { get; set; }

    public BookCopy BookCopy { get; set; }=null!;

    public User User { get; set; } =null!;

    public DateTime IssuedDate { get; set; }

    public DateTime ReturnDate  { get; set; }
}