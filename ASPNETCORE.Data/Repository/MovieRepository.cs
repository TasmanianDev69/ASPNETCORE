using ASPNETCORE.Data.Data;
using ASPNETCORE.Data.Entitys;
using ASPNETCORE.Data.Interface;
using Microsoft.EntityFrameworkCore;

namespace ASPNETCORE.Data.Repository
{
	public class MovieRepository : IMovieRepository
	{
		private readonly ASPNETCOREContext context;

		public MovieRepository(ASPNETCOREContext context)
		{
			this.context = context;
		}
		public async Task<IEnumerable<MovieEntity>> GetMoviesAsync()
		{
			if (context.Movie == null)
				return Enumerable.Empty<MovieEntity>();

			return await context.Movie.ToListAsync();
		}
		public async Task<MovieEntity?> GetMovieAsync(int id)
		{
			if (context.Movie == null)
				return null;

			return await context.Movie.FirstOrDefaultAsync(m => m.Id == id);
		}
		public async Task<MovieEntity?> AddMovieAsync(MovieEntity movie)
		{
			if (context.Movie == null || movie == null)
				return null;

			context.Movie.Add(movie);
			await context.SaveChangesAsync();

			return movie;
		}
		public async Task<MovieEntity?> UpdateMovieAsync(MovieEntity movie)
		{
			context.Attach(movie).State = EntityState.Modified;

			try
			{
				await context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				return null;
			}

			return movie;
		}
		public async Task<bool> DeleteMovieAsync(int id)
		{
			if (context.Movie == null)
				return false;

			var movie = await GetMovieAsync(id);

			if (movie == null)
				return false;

			context.Movie.Remove(movie);
			await context.SaveChangesAsync();

			return true;
		}
		public bool MovieExistsAsync(int id)
		=> (context.Movie?.Any(e => e.Id == id)).GetValueOrDefault();
	}
}
