using MVCMovie.Data;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MVCMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                   serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movie.AddRange(
                     new Movie
                     {
                         Title = "When Harry Met Sally",
                         ReleaseDate = DateTime.Parse("1989-1-11"),
                         Genre = "Romantic Comedy",
                         Price = 7.99M,
                         Rating = "R"
                     },

                     new Movie
                     {
                         Title = "Ghostbusters ",
                         ReleaseDate = DateTime.Parse("1984-3-13"),
                         Genre = "Comedy",
                         Price = 8.99M,
                         Rating = "R"
                     },

                     new Movie
                     {
                         Title = "Ghostbusters 2",
                         ReleaseDate = DateTime.Parse("1986-2-23"),
                         Genre = "Comedy",
                         Price = 9.99M,
                         Rating = "R"
                     },

                   new Movie
                   {
                       Title = "Rio Bravo",
                       ReleaseDate = DateTime.Parse("1959-4-15"),
                       Genre = "Western",
                       Price = 3.99M,
                       Rating = "R"
                   }
                );
                context.SaveChanges();
            }
        }
    }
}
