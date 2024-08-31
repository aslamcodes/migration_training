using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using ToDoApp.Data;

public class DatabaseMigrationService
{

    [ExcludeFromCodeCoverage]
    public static void MigrateInitial(IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.CreateScope();

        serviceScope.ServiceProvider.GetService<AppDbContext>().Database.Migrate();
    }
}