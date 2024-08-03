using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CollectionArt.AuctionApp.Data;

public class AuctionAppDbContextFactory : IDesignTimeDbContextFactory<AuctionAppDbContext>
{
    public AuctionAppDbContext CreateDbContext(string[] args)
    {

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<AuctionAppDbContext>()
            .UseSqlite(configuration.GetConnectionString("Default"));

        return new AuctionAppDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
