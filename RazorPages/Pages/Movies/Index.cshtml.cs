using ASPNETCORE.Logic.Interface;
using ASPNETCORE.Logic.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace RazorPages.Pages.Movies
{
    public class IndexModel : PageModel
    {
		private readonly IMovieService movieService;

		public IndexModel(IMovieService movieService)
        {
			this.movieService = movieService;
		}

        public IList<Movie> Movie { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Movie = await movieService.GetMoviesAsync();       
        }
    }
}
