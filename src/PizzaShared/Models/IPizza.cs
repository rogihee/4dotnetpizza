namespace PizzaShared.Models;

public interface IPizza
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool SonderAngebot { get; set; }
    public DateOnly AvailableSince { get; set; }
}

