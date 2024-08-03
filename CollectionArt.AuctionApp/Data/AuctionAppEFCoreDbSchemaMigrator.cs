using Microsoft.EntityFrameworkCore;
using Volo.Abp.DependencyInjection;

namespace CollectionArt.AuctionApp.Data;

public class AuctionAppEFCoreDbSchemaMigrator : ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public AuctionAppEFCoreDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the AuctionAppDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<AuctionAppDbContext>()
            .Database
            .MigrateAsync();
    }
}
