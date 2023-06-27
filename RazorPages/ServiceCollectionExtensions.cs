using ASPNETCORE.RazorPages.Configuration.Automapper;
using ASPNETCORE.Repository;
using ASPNETCORE.Repository.Context;
using ASPNETCORE.Repository.Interface;
using ASPNETCORE.Service;
using ASPNETCORE.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace ASPNETCORE.IoC
{
	public static class ServiceCollectionExtensions
	{
		public static void ConfigureDatabase(this IServiceCollection serviceCollection, string connectionString)
		{
			serviceCollection.AddDbContext<ASPNETCOREContext>(options =>
					options.UseSqlServer(connectionString,x=>x.MigrationsAssembly("ASPNETCORE.Data")));
		}
		public static void ConfigureServices(this IServiceCollection serviceCollection)
		{
			serviceCollection.AddAutoMapper(typeof(MovieProfile));

			serviceCollection.AddScoped<IMovieService, MovieService>();
			serviceCollection.AddScoped<IMovieRepository, MovieRepository>();
		}
	}
}