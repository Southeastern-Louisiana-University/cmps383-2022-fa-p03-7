using Microsoft.EntityFrameworkCore;
using FA22.P02.Web.Features;
namespace Database.Config;



public class DataContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<Listing> Listings { get; set; }
    public DbSet<ItemListing> ItemListings { get; set; }





    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>();


        modelBuilder.Entity<Item>()
            .Property(b => b.Url)
            .IsRequired();

        modelBuilder.Entity<Listing>()
            .Property(b => b.Url)
            .IsRequired();

        modelBuilder.Entity<ItemListing>()
        .Property(b => b.Url)
            .IsRequired();




    }




}