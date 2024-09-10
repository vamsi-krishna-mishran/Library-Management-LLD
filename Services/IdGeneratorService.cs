

public class IdGenerator{
    private static int _id=0;
    public int GenerateId(){
        _id+=1;
        return _id;
    }
}