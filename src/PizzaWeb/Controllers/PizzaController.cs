using Microsoft.AspNetCore.Mvc;

namespace PizzaWeb.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class PizzaController : ControllerBase, IPizzaApiService // define the contract server side
{
    private readonly PizzaCoreService _pizzaCoreService;
    private readonly ILogger<PizzaController> _logger;

    public PizzaController(PizzaCoreService pizzaService, ILogger<PizzaController> logger)
    {
        _pizzaCoreService = pizzaService;
        _logger = logger;
    }

    [HttpGet]
    public Task<List<Pizza>?> Get()
    {
        return _pizzaCoreService.GetList();
    }
}