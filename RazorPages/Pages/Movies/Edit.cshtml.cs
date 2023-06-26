using ASPNETCORE.Logic.Interface;
using ASPNETCORE.Logic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPages.Pages.Movies
{
	public class EditModel : PageModel
	{
		private readonly IMovieService movieService;

		public EditModel(IMovieService movieService)
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
			Movie = movie;
			return Page();
		}

		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see https://aka.ms/RazorPagesCRUD.
		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			Movie? movie = await movieService.UpdateMovieAsync(Movie);

			if (movie == null)
			{
				return NotFound();
			}

			return RedirectToPage("./Index");
		}
	}
}
