namespace PizzaShared.Services;

// TODO 05: define the contract in shared
public interface IPizzaApiService
{
    public Task<List<Pizza>?> Get();
}