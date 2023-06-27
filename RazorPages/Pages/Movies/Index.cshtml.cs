using ASPNETCORE.Service.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Viewmodel;

namespace RazorPages.Pages.Movies
{
    public class IndexModel : PageModel
    {
		private readonly IMovieService movieService;
		private readonly IMapper mapper;

		public IndexModel(IMovieService movieService,IMapper mapper)
        {
			this.movieService = movieService;
			this.mapper = mapper;
		}

        public IList<MovieViewmodel> Movie { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Movie = mapper.Map<IList<MovieViewmodel>>(await movieService.GetMoviesAsync());       
        }
    }
}
