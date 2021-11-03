namespace PizzaShared.Services;

// TODO: define the contract in shared
public interface IPizzaApiService
{
    public Task<List<Pizza>?> Get();
}