

public class RackService:BaseService{

    

    public List<int> AddRacks(List<Rack> racks){
        foreach(Rack rack in racks){
            _repo.Racks.Add(rack.Id,rack);
        }
        return racks.Select(rack=>rack.Id).ToList();
    }
    public int AddRack(Rack rack){
        _repo.Racks.Add(rack.Id,rack);
        return rack.Id;
    }

    public Rack? GetFreeRack(int bookId){
        List<int> rackIds=_repo.Racks.Keys
                          .ToList();
        rackIds.Sort();

        List<int> occupiedRacks=_repo.BookCopies.Values
                                .Where(copy=>copy.Book.Id==bookId)
                                .Select(cp=>cp.Rack.Id)
                                .ToList();
        occupiedRacks.Sort();

        foreach(int rackId in rackIds){
            if(!occupiedRacks.Contains(rackId)){
                return _repo.Racks[rackId];
            }
        }
        return null;



    }
}