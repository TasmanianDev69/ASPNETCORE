using ASPNETCORE.Data.Entitys;
using Microsoft.EntityFrameworkCore;

namespace ASPNETCORE.Data.Data;
	public class ASPNETCOREContext : DbContext
	{
		public ASPNETCOREContext(DbContextOptions<ASPNETCOREContext> options)
			: base(options)
		{
		}

		public DbSet<MovieEntity> Movie { get; set; } = default!;
	}
