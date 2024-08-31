using Microsoft.EntityFrameworkCore;
using ToDoApp.Data;
using TodoMVC.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var dbhost = Environment.GetEnvironmentVariable("DB_HOST");
var dbpass = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");
var dbname = Environment.GetEnvironmentVariable("DB_NAME");

var connectionString = @$"Server={dbhost};Database={dbname};User Id=sa;Password={dbpass};TrustServerCertificate=True";


builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
