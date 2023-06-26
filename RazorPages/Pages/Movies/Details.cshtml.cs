using ASPNETCORE.Logic.Interface;
using ASPNETCORE.Logic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPages.Pages.Movies
{
    public class DetailsModel : PageModel
    {
		private readonly IMovieService movieService;

		public DetailsModel(IMovieService movieService)
        {
			this.movieService = movieService;
		}

      public Movie Movie { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await movieService.GetMovieAsync(id.Value);
            if (movie == null)
            {
                return NotFound();
            }
            else 
            {
                Movie = movie;
            }
            return Page();
        }
    }
}
