namespace Business.Responses.Fuel;

public class AddTransmissonResponse
{ 
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }

    public AddTransmissonResponse(int id, string name, DateTime createdAt)
    {
        Id = id;
        Name = name;
        CreatedAt = createdAt;
    }
}
