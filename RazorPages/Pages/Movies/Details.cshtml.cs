using ASPNETCORE.Service.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Viewmodel;

namespace RazorPages.Pages.Movies
{
    public class DetailsModel : PageModel
    {
		private readonly IMovieService movieService;
		private readonly IMapper mapper;

		public DetailsModel(IMovieService movieService,IMapper mapper)
        {
			this.movieService = movieService;
			this.mapper = mapper;
		}

      public MovieViewmodel Movie { get; set; } = default!; 

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
                Movie = mapper.Map<MovieViewmodel>(movie);
            }
            return Page();
        }
    }
}
