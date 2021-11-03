using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Logging;
using PizzaShared.Services;

namespace PizzaComponents.Services;

public class PizzaClient : IAsyncDisposable, IPizzaClient
{
    private ILogger _logger;
    private HubConnection? _hubConnection;

    public PizzaClient(ILogger<PizzaClient> logger)
    {
        _logger = logger;
    }

    public async Task Connect(string rootUri)
    {
        if (_hubConnection is { State: HubConnectionState.Connected })
        {
            _logger.LogInformation("Already connected: " + _hubConnection.ConnectionId);
            return;
        }
        var hubUrl = rootUri.TrimEnd('/') + IPizzaHub.HubUrl;
        // create the connection using the .NET SignalR client
        _hubConnection = new HubConnectionBuilder()
            .WithUrl(hubUrl)
            .WithAutomaticReconnect()
            // RvdH: this does NOT work in .NET 5!
            //.AddJsonProtocol(o =>
            //{
            //    o.PayloadSerializerOptions.WriteIndented = true;
            //    o.PayloadSerializerOptions.Converters.Add(new MyConverter());
            //})
            .Build();

        // add handler for receiving messages
        _hubConnection.On<int, double>(nameof(IPizzaNotifications.SonderAngebot), HandleSonderAngebotChanged);
            
        _hubConnection.Closed += (e) =>
        {
            _logger.LogInformation($"Closed connection: {e.Message}");
            return Task.CompletedTask;
        };
        _hubConnection.Reconnecting += (e) =>
        {
            _logger.LogInformation($"Reconnecting connection: {e.Message}");
            return Task.CompletedTask;
        };
        _hubConnection.Reconnected += (s) =>
        {
            _logger.LogInformation($"Reconnected! {s}");
            return Task.CompletedTask;
        };
        // start the connection
        await _hubConnection.StartAsync();
        _logger.LogInformation("Connect: " + _hubConnection.ConnectionId);
    }

    private Task HandleSonderAngebotChanged(int id, double price)
    {
        SonderAngebotEvent?.Invoke(id, price);
        return Task.CompletedTask;
    }

    public async Task Disconnect()
    {
        if (_hubConnection != null)
        {
            // disconnect the client
            await _hubConnection.StopAsync();
            // There is a bug in the mono/SignalR client that does not
            // close connections even after stop/dispose
            // see https://github.com/mono/mono/issues/18628
            // this means the demo won't show "xxx left the chat" since 
            // the connections are left open
            await _hubConnection.DisposeAsync();
            _hubConnection = null;
        }
    }

    public async ValueTask DisposeAsync()
    {
        await Disconnect();
    }

    public event Action<int, double>? SonderAngebotEvent;
}