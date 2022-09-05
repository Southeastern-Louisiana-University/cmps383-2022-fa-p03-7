using Microsoft.EntityFrameworkCore;
using Database;
using FA22.P02.Web.Features;

namespace Models


{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DataContext(

                    serviceProvider.GetRequiredService
                    <DbContextOptions<DataContext>>()
                    ))
            {
                // Look for any movies.
                // if (context.Products.Any())
                // {
                //     return;   // DB has been seeded
                // }

                context.Products.Add(


                    new Product
                    {

                        Name = "Super Mario World",
                        Description = "Super Nintendo (SNES) System. Mint Condition",
                    }
                );
                context.Products.Add(
                    new Product
                    {

                        Name = "Donkey Kong 64",
                        Description = "Moderate Condition Donkey Kong 64 cartridge for the Nintendo 64",
                    }
                );
                context.Products.Add(
                    new Product
                    {

                        Name = "Half-Life 2: Collector's Edition",
                        Description = "Good condition with all 5 CDs, booklets, and material from original",
                    }
                );



                context.SaveChanges();
            }

        }
    }
}

