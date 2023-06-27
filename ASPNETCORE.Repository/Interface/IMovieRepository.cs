using ASPNETCORE.Data;

namespace ASPNETCORE.Repository.Interface;

public interface IMovieRepository
{
	Task<Movie?> AddMovieAsync(Movie movie);
	Task<bool> DeleteMovieAsync(int id);
	Task<Movie?> GetMovieAsync(int id);
	Task<IList<Movie>> GetMoviesAsync();
	bool MovieExists(int id);
	Task<Movie?> UpdateMovieAsync(Movie movie);
}
