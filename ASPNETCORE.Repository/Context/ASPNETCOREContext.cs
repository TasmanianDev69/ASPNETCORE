using ASPNETCORE.Data;
using Microsoft.EntityFrameworkCore;

namespace ASPNETCORE.Repository.Context;
	public class ASPNETCOREContext : DbContext
	{
		public ASPNETCOREContext(DbContextOptions<ASPNETCOREContext> options)
			: base(options)
		{
		}

		public DbSet<Movie> Movie { get; set; } = default!;
	}
