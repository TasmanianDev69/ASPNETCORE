using ASPNETCORE.Data;
using ASPNETCORE.Service.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Viewmodel;

namespace RazorPages.Pages.Movies
{
	public class EditModel : PageModel
	{
		private readonly IMovieService movieService;
		private readonly IMapper mapper;

		public EditModel(IMovieService movieService, IMapper mapper)
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

			var movie = await movieService.GetMovieAsync(id.Value);
			if (movie == null)
			{
				return NotFound();
			}
			Movie = mapper.Map<MovieViewmodel>(movie);
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

			Movie? movie = await movieService.UpdateMovieAsync(mapper.Map<Movie>(Movie));

			if (movie == null)
			{
				return NotFound();
			}

			return RedirectToPage("./Index");
		}
	}
}
