

public class LibraryService:BaseService{



    public Library AddLibrary(Library library){
        _repo.Libraries.Add(library.Id, library);

        return library;
    }

    public Library RemoveLibrary(Library library){
        Library lib=_repo.Libraries[library.Id];
        _repo.Libraries.Remove(library.Id);
        return lib;
    }
}