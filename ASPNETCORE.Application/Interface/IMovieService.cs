using ASPNETCORE.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETCORE.Logic.Interface;
public interface IMovieService
{
	Task<Movie?> AddMovieAsync(Movie movie);
	Task<bool> DeleteMovieAsync(int id);
	Task<Movie?> GetMovieAsync(int id);
	Task<IEnumerable<Movie>> GetMoviesAsync();
	bool MovieExists(int id);
	Task<Movie?> UpdateMovieAsync(Movie movie);
}
