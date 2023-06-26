using ASPNETCORE.Logic.Interface;
using ASPNETCORE.Logic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPages.Pages.Movies
{
    public class DeleteModel : PageModel
    {
		private readonly IMovieService movieService;

		public DeleteModel(IMovieService movieService)
        {
			this.movieService = movieService;
		}

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
			var isRemoved = await movieService.DeleteMovieAsync(id.Value);


			if (!isRemoved)
            {
                return NotFound();
            }

            return RedirectToPage("./Index");
        }
    }
}
