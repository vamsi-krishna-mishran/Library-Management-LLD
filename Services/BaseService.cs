

public class BaseService{

    protected readonly Database _repo;
    public BaseService(){
        _repo = Database.GetInstance();
    }
}