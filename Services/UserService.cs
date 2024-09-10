

public class UserService:BaseService{

    public User? GetUser(int id){
        return _repo.Users.Values.Where(user=>user.Id == id).FirstOrDefault();
    }

    public User AddUser(User user){
        _repo.Users.Add(user.Id,user);
        return user;
    }
}