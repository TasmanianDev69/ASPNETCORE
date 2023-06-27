using ASPNETCORE.Data;
using ASPNETCORE.Service.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Viewmodel;

namespace RazorPages.Pages.Movies
{
    public class CreateModel : PageModel
    {
		private readonly IMovieService movieService;
		private readonly IMapper mapper;

		public CreateModel(IMovieService movieService,IMapper mapper)
        {
			this.movieService = movieService;
			this.mapper = mapper;
		}

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public MovieViewmodel Movie { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid ||  Movie == null)
            {
                return Page();
            }

            var result = await movieService.AddMovieAsync(mapper.Map<Movie>(Movie));

            if (result == null)
            {
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}
