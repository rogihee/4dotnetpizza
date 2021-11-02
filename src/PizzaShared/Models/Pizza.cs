namespace PizzaShared.Models;

public class Pizza
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Ingredients { get; set; }
    public DateTime AvailableSince { get; set; } // TODO: DateOnly not supported yet for serialization!
    public double Price { get; set; }
    public bool SonderAngebot { get; set; }
}

