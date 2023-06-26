using ASPNETCORE.Data.Data;
using ASPNETCORE.Data.Interface;
using ASPNETCORE.Data.Repository;
using ASPNETCORE.Logic.Configuration.Automapper;
using ASPNETCORE.Logic.Interface;
using ASPNETCORE.Logic.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ASPNETCORE.IoC
{
	public static class ServiceCollectionExtensions
	{
		public static void ConfigureDatabase(this IServiceCollection serviceCollection, string connectionString)
		{
			serviceCollection.AddDbContext<ASPNETCOREContext>(options =>
					options.UseSqlServer(connectionString));
		}
		public static void ConfigureServices(this IServiceCollection serviceCollection)
		{
			serviceCollection.AddAutoMapper(typeof(MovieProfile));

			serviceCollection.AddScoped<IMovieService, MovieService>();
			serviceCollection.AddScoped<IMovieRepository, MovieRepository>();
		}
	}
}