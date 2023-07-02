using ASPNETCORE.Data;
using ASPNETCORE.Service.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.Models;
using RazorPages.Viewmodel;

namespace MVC.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService movieService;
        private readonly IMapper mapper;

        public MoviesController(IMovieService movieService, IMapper mapper)
        {
            this.movieService = movieService;
            this.mapper = mapper;
        }

        // GET: Movies
        public async Task<IActionResult> Index(string searchString,string movieGenre)
        {
            var movies = mapper.Map<IList<MovieViewModel>>(await movieService.GetMoviesByTitleAndGenreAsync(searchString,null));
            var genres = await movieService.GetGenresAsync();
            var movieGenreVm = new MovieGenreViewModel
            {
                Genres = new SelectList(genres),
                Movies = movies.ToList()
            };
            return View(movieGenreVm);
        }
        [HttpPost]
        public string Index(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }
        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = mapper.Map<MovieViewModel>(await movieService.GetMovieAsync(id.Value));
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Genre,Price,Rating")] MovieViewModel movie)
        {
            if (ModelState.IsValid)
            {
                await movieService.AddMovieAsync(mapper.Map<Movie>(movie));
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
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

            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Genre,Price,Rating")] Movie movie)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                Movie? movieCreated = await movieService.UpdateMovieAsync(mapper.Map<Movie>(movie));

                if (movie == null)
                {
                    return NotFound();
                }

                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            await movieService.DeleteMovieAsync(id);

            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return movieService.MovieExists(id);
        }
    }
}
