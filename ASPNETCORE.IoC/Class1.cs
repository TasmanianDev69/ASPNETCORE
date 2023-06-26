using Microsoft.Extensions.DependencyInjection;

namespace ASPNETCORE.IoC
{
	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection ConfigureServices(this IServiceCollection serviceCollection)
		{
			return serviceCollection;
		}
	}
}