using ASPNETCORE.Data.Interface;
using ASPNETCORE.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace ASPNETCORE.IoC
{
	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection ConfigureServices(this IServiceCollection serviceCollection)
		{
			serviceCollection.AddScoped<IMovieRepository, MovieRepository>();
			return serviceCollection;
		}
	}
}