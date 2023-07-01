using ASPNETCORE.Service.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPages.Viewmodel;

namespace RazorPages.Pages.Movies
{
	public class IndexModel : PageModel
	{
		private readonly IMovieService movieService;
		private readonly IMapper mapper;

		public IndexModel(IMovieService movieService, IMapper mapper)
		{
			this.movieService = movieService;
			this.mapper = mapper;
		}

		public IList<MovieViewmodel> Movie { get; set; } = default!;

		[BindProperty(SupportsGet = true)]
		public string? SearchString { get; set; }

		public SelectList? Genres { get; set; }

		[BindProperty(SupportsGet = true)]
		public string? MovieGenre { get; set; }

		public async Task OnGetAsync()
		{
			Genres = new SelectList(await movieService.GetGenresAsync());
			Movie = mapper.Map<IList<MovieViewmodel>>(await movieService.GetMoviesByTitleAndGenreAsync(SearchString, MovieGenre));
		}
	}
}
