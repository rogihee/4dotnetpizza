namespace PizzaShared.Services;

public interface IPizzaClient
{
    Task Connect(string rootUri); // Connect to Hub, not session
    Task Disconnect(); // Disconnect from Hub, not session

    event Action<int, double> SonderAngebotEvent;
}