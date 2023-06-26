using ASPNETCORE.Logic.Interface;
using ASPNETCORE.Logic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPages.Pages.Movies
{
    public class CreateModel : PageModel
    {
		private readonly IMovieService movieService;

		public CreateModel(IMovieService movieService)
        {
			this.movieService = movieService;
		}

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Movie Movie { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid ||  Movie == null)
            {
                return Page();
            }

            var result = await movieService.AddMovieAsync(Movie);

            if (result == null)
            {
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}
