using ASPNETCORE.Data;
using ASPNETCORE.MVC.Configuration.Automapper;
using ASPNETCORE.Repository;
using ASPNETCORE.Repository.Context;
using ASPNETCORE.Repository.Interface;
using ASPNETCORE.Service;
using ASPNETCORE.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace MVC
{
    public static class StartupExtensions
    {
        public static void ConfigureDatabase(this IServiceCollection serviceCollection, string connectionString)
        {
            serviceCollection.AddDbContext<ASPNETCOREContext>(options =>
                    options.UseSqlServer(connectionString, x => x.MigrationsAssembly("ASPNETCORE.Repository")));
        }
        public static void ConfigureServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAutoMapper(typeof(MovieProfile));

            serviceCollection.AddScoped<IMovieService, MovieService>();
            serviceCollection.AddScoped<IMovieRepository, MovieRepository>();
        }
        public static void SeedDatabase(this IServiceProvider serviceProvider)
        {
            using (var context = new ASPNETCOREContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ASPNETCOREContext>>()))
            {
                if (context == null || context.Movie == null)
                {
                    throw new ArgumentNullException("Null RazorPagesMovieContext");
                }

                if (context.Movie.Any())
                {
                    return;
                }

                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "When Harry Met Sally",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
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
