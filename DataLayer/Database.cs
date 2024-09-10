

public class Database{

    public Dictionary<int,User> Users { get; set; }=null!;
    public Dictionary<int,BookCopy> BookCopies { get; set; }=null!;

    public Dictionary<int,Book> Books { get; set; }=null!;

    public Dictionary<int,Borrow> Borrows { get; set; }=null!;

    public Dictionary<int,Rack> Racks { get; set; }=null!;

    public Dictionary<int,Library> Libraries { get; set; }=null!;


    private Database(){
        Users=new Dictionary<int,User>();
        Books=new Dictionary<int,Book>();
        BookCopies=new Dictionary<int,BookCopy>();
        Racks=new Dictionary<int,Rack>();
        Libraries=new Dictionary<int,Library>();
        Borrows=new Dictionary<int, Borrow>();

    }

    private static Database _instance=null!;
    private static readonly object _lockObj=new object();

    public static Database GetInstance(){

        lock( _lockObj){
            if(_instance==null){
                _instance=new Database();
            }
            return _instance;
        }
    }
    

}