

/// <summary>
/// This is a simple Unique Id Generator
/// service that always provides you with
/// unique Id ranging from 1 to int.MaxValue;
/// </summary>
public class IdGenerator{
    private static int _id=0;
    public int GenerateId(){
        _id+=1;
        return _id;
    }
}