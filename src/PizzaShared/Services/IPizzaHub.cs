namespace PizzaShared.Services;

public interface IPizzaNotifications
{
    Task SonderAngebot(int id, double discount);
}

public interface IPizzaHub : IPizzaNotifications
{
    public const string HubUrl = "/pizzahub";
}