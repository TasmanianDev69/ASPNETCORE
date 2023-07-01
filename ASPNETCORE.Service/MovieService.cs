using ASPNETCORE.Data;
using ASPNETCORE.Repository.Interface;
using ASPNETCORE.Service.Interface;

namespace ASPNETCORE.Service
{
	public class MovieService : IMovieService
	{
		private readonly IMovieRepository movieRepository;

		public MovieService(IMovieRepository movieRepository)
		{
			this.movieRepository = movieRepository;
		}
		public async Task<Movie?> AddMovieAsync(Movie movie)
		{
			if (movie == null)
				return null;
			return await movieRepository.AddMovieAsync(movie);
		}

		public async Task<bool> DeleteMovieAsync(int id)
		=> await movieRepository.DeleteMovieAsync(id);

		public async Task<Movie?> GetMovieAsync(int id)
		=> await movieRepository.GetMovieAsync(id);

		public async Task<IList<Movie>> GetMoviesAsync()
		=> await movieRepository.GetMoviesAsync();

		public async Task<IList<Movie>> GetMoviesByTitleAndGenreAsync(string? title, string? genre)
			=> await movieRepository.GetMoviesByTitleAndGenreAsync(title, genre);
		public async Task<IList<string>> GetGenresAsync()
			=> await movieRepository.GetGenresAsync();

		public bool MovieExists(int id)
		 => movieRepository.MovieExists(id);

		public async Task<Movie?> UpdateMovieAsync(Movie movie)
		{
			if (movie == null)
				return null;

			return await movieRepository.UpdateMovieAsync(movie);
		}
	}
}
