// TODO 03: Minimal startup

using PizzaCore.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add Pizza core services to the container.
builder.Services.AddSignalR();
builder.Services.AddPizzaCoreServices();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();
app.MapControllers();
// TODO 09: map the pizza hub
app.MapHub<PizzaHub>(IPizzaHub.HubUrl);
// TODO 06: For the sake of example switch to a hosted page instead of HTML
// app.MapFallbackToFile("index.html");
app.MapFallbackToPage("{*path:nonfile}", "/PizzaApp");
app.Run();
