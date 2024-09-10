
public class BorrowService:BaseService{

    public Borrow AddBorrow(Borrow borrow){
        _repo.Borrows.Add(borrow.Id,borrow);
        return borrow;
    }

    public List<int>? GetBorrowCopyIds(int userId){
        List<Borrow> borrows=_repo.Borrows.Values.Where(borrow=>borrow.User.Id == userId).ToList();
        return borrows.Select(borrow=>borrow.BookCopy.Id).ToList();
    }
    public Borrow? GetBorrow(int copyId){
        return _repo.Borrows.Values.Where(borrow=>borrow.BookCopy.Id == copyId).FirstOrDefault();
    }

}