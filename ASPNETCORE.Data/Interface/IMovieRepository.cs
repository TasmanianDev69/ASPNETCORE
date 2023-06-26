using ASPNETCORE.Data.Entitys;

namespace ASPNETCORE.Data.Interface;

public interface IMovieRepository
{
	Task<MovieEntity?> AddMovieAsync(MovieEntity movie);
	Task<bool> DeleteMovieAsync(int id);
	Task<MovieEntity?> GetMovieAsync(int id);
	Task<IList<MovieEntity>> GetMoviesAsync();
	bool MovieExists(int id);
	Task<MovieEntity?> UpdateMovieAsync(MovieEntity movie);
}
