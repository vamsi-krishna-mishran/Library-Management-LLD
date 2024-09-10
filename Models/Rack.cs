

public class Rack{

    public int Id { get; set; }

    public Library Library { get; set; }=null!;

    public string Name { get; set; }=null!;

    public int Floor {get;set;}

    public int RackCapacity {get;set;}

}