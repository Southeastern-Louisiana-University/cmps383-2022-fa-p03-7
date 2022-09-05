using Microsoft.EntityFrameworkCore;
using Database.Config;
using FA22.P03.Web.Features.Products;
using System;
using System.Linq;


namespace SeedData.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DataContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<DataContext>>()))
            {
                // Look for any movies.
                if (context.Product.Any())
                {
                    return;   // DB has been seeded
                }

                context.Product.AddRange(
            {

                    new ProductDto
                    {
                        //  Id = currentId++,
                        Id = 1,
                        Name = "Super Mario World",
                        Description = "Super Nintendo (SNES) System. Mint Condition",
                    };

                    new ProductDto
                    {
                        Id = 2,
                        Name = "Donkey Kong 64",
                        Description = "Moderate Condition Donkey Kong 64 cartridge for the Nintendo 64",
                    };

                    new ProductDto
                    {
                        Id = 3,
                        Name = "Half-Life 2: Collector's Edition",
                        Description = "Good condition with all 5 CDs, booklets, and material from original",
                    }

                    ;


                    context.SaveChanges();
                }
            }
        }
    }