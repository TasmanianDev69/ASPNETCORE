using ASPNETCORE.Data;
using ASPNETCORE.Repository.Context;
using ASPNETCORE.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace ASPNETCORE.Repository;
public class MovieRepository : IMovieRepository
{
    private readonly ASPNETCOREContext context;

    public MovieRepository(ASPNETCOREContext context)
    {
        this.context = context;
    }
    public async Task<Movie?> AddMovieAsync(Movie movie)
    {
        if (context.Movie == null || movie == null)
            return null;

        context.Movie.Add(movie);
        await context.SaveChangesAsync();

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
    public async Task<Movie?> GetMovieAsync(int id)
    {
        if (context.Movie == null)
            return null;

        return await context.Movie.FirstOrDefaultAsync(m => m.Id == id);
    }
    public async Task<IList<Movie>> GetMoviesAsync()
    {
        if (context.Movie == null)
            return new List<Movie>();

        return await context.Movie.ToListAsync();
    }
    public async Task<IList<Movie>> GetMoviesByTitleAndGenreAsync(string? title, string? genre)
    {
        if (context.Movie == null)
            return new List<Movie>();

        var movies = from movie in context.Movie
                     select movie;

        if (!string.IsNullOrEmpty(title))
        {
            movies = movies.Where(movie => movie.Title.Contains(title));
        }
		if (!string.IsNullOrEmpty(genre))
		{
			movies = movies.Where(movie => movie.Genre == genre);
		}

		return await movies.ToListAsync();
    }
	public async Task<IList<string>> GetGenresAsync()
	{
		if (context.Movie == null)
			return new List<string>();

		IQueryable<string> genreQuery = from m in context.Movie
										orderby m.Genre
										select m.Genre;

		return await genreQuery.Distinct().ToListAsync();
	}
	public bool MovieExists(int id)
            => (context.Movie?.Any(e => e.Id == id)).GetValueOrDefault();
    public async Task<Movie?> UpdateMovieAsync(Movie movie)
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
}

