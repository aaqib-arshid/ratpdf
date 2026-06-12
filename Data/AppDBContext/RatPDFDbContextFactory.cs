using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ratpdf.Data.AppDBContext;

/// <summary>Design-time factory for EF Core migrations (dotnet ef).</summary>
public class RatPDFDbContextFactory : IDesignTimeDbContextFactory<RatPDFDbContext>
{
    public RatPDFDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false)
            .AddJsonFile("appsettings.Development.json", optional: true)
            .AddEnvironmentVariables()
            .Build();

        var connectionString = configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

        var optionsBuilder = new DbContextOptionsBuilder<RatPDFDbContext>();
        optionsBuilder.UseSqlServer(connectionString);

        return new RatPDFDbContext(optionsBuilder.Options);
    }
}
