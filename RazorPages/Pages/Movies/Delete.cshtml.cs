using ASPNETCORE.Service.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Viewmodel;

namespace RazorPages.Pages.Movies
{
    public class DeleteModel : PageModel
    {
		private readonly IMovieService movieService;
		private readonly IMapper mapper;

		public DeleteModel(IMovieService movieService,IMapper mapper)
        {
			this.movieService = movieService;
			this.mapper = mapper;
		}

        [BindProperty]
      public MovieViewmodel Movie { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = mapper.Map<MovieViewmodel>(await movieService.GetMovieAsync(id.Value));

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
