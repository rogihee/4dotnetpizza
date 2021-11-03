using System.Net.Http.Json;
using Microsoft.Extensions.Logging;
using PizzaShared.Models;
using PizzaShared.Services;

namespace PizzaComponents.Services;

public class PizzaApiService : IPizzaApiService
{
    private readonly ILogger _logger;
    private readonly HttpClient _http;

    public PizzaApiService(HttpClient httpClient, ILogger<PizzaApiService> logger)
    {
        _http = httpClient;
        _logger = logger;
    }

    public Task<List<Pizza>?> Get()
    {
        // TODO: JsonSourceGenerator
#pragma warning disable IL2026 // Members annotated with 'RequiresUnreferencedCodeAttribute' require dynamic access otherwise can break functionality when trimming application code
        return _http.GetFromJsonAsync<List<Pizza>>("api/pizza/"+nameof(IPizzaApiService.Get));
#pragma warning restore IL2026 // Members annotated with 'RequiresUnreferencedCodeAttribute' require dynamic access otherwise can break functionality when trimming application code
    }
}