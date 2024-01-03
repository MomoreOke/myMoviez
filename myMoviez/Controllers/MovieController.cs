using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using myMoviez.Data;
using myMoviez.Models;

namespace myMoviez.Controllers
{
    public class MovieController : Controller
    {
        private readonly MyMoviezDBContext _context;

        public MovieController(MyMoviezDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var objmoviesList = _context.Movies.Include("Genre");
            return View(objmoviesList);
        }

        //Get
        [HttpGet]
        public IActionResult Create()
        {
            LoadGenres();
            return View();
        }

        [NonAction]
        private void LoadGenres()
        {
            var genres= _context.Genres.ToList();
            ViewBag.Genres = new SelectList(genres, "GenreId", "GenreName");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create (Movie movie)
        {
            //if (ModelState.IsValid)
            
                _context.Movies.Add(movie);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            
            //ViewData["GenreId"] = new SelectList(_context.Genres, "GenreId", "GenreName", movie.GenreId);
           // return View();
        }

        public IActionResult Edit(int? MovieId)
        {
            if(MovieId == null || MovieId ==0)
            {
                return NotFound();
            }
            var moviefromDB = _context.Movies.Find(MovieId);
            if (moviefromDB == null)
            {
                return NotFound();
            }
            ViewData["GenreId"] = new SelectList(_context.Genres, "GenreId", "GenreName", moviefromDB.GenreId);
            return View(moviefromDB);
        }

        //Post 
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Edit(Movie movie)
        { if (ModelState.IsValid)
            {
                _context.Movies.Update(movie);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["GenreId"] = new SelectList(_context.Genres, "GenreId", "GenreName", movie.GenreId);
            return View(movie);
        }

        public IActionResult Delete (int? MovieId)
        {
            if (MovieId == null || MovieId == 0) 
            {
                return NotFound();
            }
            var moviefromDB = _context.Movies.Find(MovieId);
            if (moviefromDB == null)
            {
                return NotFound();
            }
            return View(moviefromDB);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? MovieId)
        {
            var movie = _context.Movies.Find(MovieId);
            if (movie == null ) { return NotFound(); }
            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
