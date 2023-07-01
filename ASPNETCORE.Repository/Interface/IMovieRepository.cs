using ASPNETCORE.Data;

namespace ASPNETCORE.Repository.Interface;

public interface IMovieRepository
{
	Task<Movie?> AddMovieAsync(Movie movie);
	Task<bool> DeleteMovieAsync(int id);
	Task<Movie?> GetMovieAsync(int id);
	Task<IList<Movie>> GetMoviesAsync();
	Task<IList<Movie>> GetMoviesByTitleAndGenreAsync(string? title, string? genre);
	Task<IList<string>> GetGenresAsync();

	bool MovieExists(int id);
	Task<Movie?> UpdateMovieAsync(Movie movie);
}
