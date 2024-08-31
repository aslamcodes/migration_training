using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var dbhost = Environment.GetEnvironmentVariable("DB_HOST");
var dbpass = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");
var dbname = Environment.GetEnvironmentVariable("DB_NAME");
var connectionString = @$"Server={dbhost};Database={dbname};User Id=sa;Password={dbpass};TrustServerCertificate=true";


builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

var app = builder.Build();

DatabaseMigrationService.MigrateInitial(app);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Apply CORS middleware
app.UseCors("AllowAll");

app.MapGet("/todo", async (AppDbContext context) =>
{
    return await context.Tasks.ToListAsync();
})
.WithOpenApi();

app.MapPost("/todo", async (AppDbContext context, [FromBody] TaskItem task) =>
{
    await context.Tasks.AddAsync(task);
    await context.SaveChangesAsync();
    return Results.Created($"/todo/{task.Id}", task);
});

app.MapPut("/todo/{id}", async (int id, [FromBody] TaskUpdateDto updateDto, AppDbContext context) =>
{
    var task = await context.Tasks.FindAsync(id);
    if (task == null)
    {
        return Results.NotFound();
    }

    task.IsCompleted = updateDto.IsCompleted;

    await context.SaveChangesAsync();

    return Results.NoContent();
});

app.Run();

public class TaskUpdateDto
{
    public bool IsCompleted { get; set; }
}