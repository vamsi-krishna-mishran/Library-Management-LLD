
/// <summary>
/// This is the base service having database instance _repo.
/// </summary>
public class BaseService{

    protected readonly Database _repo;
    public BaseService(){
        _repo = Database.GetInstance();
    }
}