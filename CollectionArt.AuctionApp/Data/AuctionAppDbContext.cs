using CollectionArt.AuctionApp.Entities.Auctions;
using CollectionArt.AuctionApp.Entities.Bids;
using CollectionArt.AuctionApp.Entities.Galleries;
using CollectionArt.AuctionApp.Entities.Items;
using CollectionArt.AuctionApp.Entities.Profiles;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace CollectionArt.AuctionApp.Data;

public class AuctionAppDbContext : AbpDbContext<AuctionAppDbContext>
{
    public AuctionAppDbContext(DbContextOptions<AuctionAppDbContext> options)
        : base(options)
    {
    }
    public DbSet<Auction> Auctions { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<Bid> Bids { get; set; }
    public DbSet<Gallery> Galleries { get; set; }
    public DbSet<UserProfile> Profiles { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();

        /* Configure your own entities here */

        builder.Entity<Auction>(b =>
        {
            b.HasOne<IdentityUser>().WithMany().HasForeignKey(x => x.WinnerId).IsRequired(false);
            b.HasOne<Item>().WithMany().HasForeignKey(x => x.ItemId).IsRequired();
           
        });
        builder.Entity<Item>(b =>
        {
            b.HasOne<IdentityUser>().WithMany().HasForeignKey(x => x.OwnerId).IsRequired();
            b.HasOne<IdentityUser>().WithMany().HasForeignKey(x => x.FirstOwnerId).IsRequired();

        });
        builder.Entity<Bid>(b =>
        {
            b.HasOne<IdentityUser>().WithMany().HasForeignKey(x => x.UserId).IsRequired();
            b.HasOne<Auction>().WithMany().HasForeignKey(x => x.AuctionId).IsRequired();

        });
        builder.Entity<Gallery>(b =>
        {
            b.HasOne<Item>().WithMany().HasForeignKey(x => x.ItemId).IsRequired();
      

        });
        builder.Entity<UserProfile>(b =>
        {
            b.HasOne<IdentityUser>().WithMany().HasForeignKey(x => x.UserId).IsRequired();


        });
    }
}
