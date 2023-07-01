using ASPNETCORE.Data;

namespace ASPNETCORE.Service.Interface;
public interface IMovieService
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
