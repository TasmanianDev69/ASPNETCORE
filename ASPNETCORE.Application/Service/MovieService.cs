using ASPNETCORE.Data.Entitys;
using ASPNETCORE.Data.Interface;
using ASPNETCORE.Logic.Interface;
using ASPNETCORE.Logic.Models;
using AutoMapper;
using System.Collections;

namespace ASPNETCORE.Logic.Service
{
	public class MovieService : IMovieService
	{
		private readonly IMovieRepository movieRepository;
		private readonly IMapper mapper;

		public MovieService(IMovieRepository movieRepository, IMapper mapper)
		{
			this.movieRepository = movieRepository;
			this.mapper = mapper;
		}
		public async Task<Movie?> AddMovieAsync(Movie movie)
		{
			if (movie == null)
				return null;

			var movieEntity = mapper.Map<MovieEntity>(movie);
			return mapper.Map<Movie>(await movieRepository.AddMovieAsync(movieEntity));
		}

		public async Task<bool> DeleteMovieAsync(int id)
		=> await movieRepository.DeleteMovieAsync(id);

		public async Task<Movie?> GetMovieAsync(int id)
		=> mapper.Map<Movie>(await movieRepository.GetMovieAsync(id));

		public async Task<IList<Movie>> GetMoviesAsync()
		=> mapper.Map<IList<Movie>>(await movieRepository.GetMoviesAsync());

		public bool MovieExists(int id)
		 => movieRepository.MovieExists(id);

		public async Task<Movie?> UpdateMovieAsync(Movie movie)
		{
			if (movie == null)
				return null;

			var movieEntity = mapper.Map<MovieEntity>(movie);
			return mapper.Map<Movie>(await movieRepository.UpdateMovieAsync(movieEntity));
		}
	}
}
