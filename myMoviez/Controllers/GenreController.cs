using Microsoft.AspNetCore.Mvc;
using myMoviez.Data;
using myMoviez.Models;

namespace myMoviez.Controllers
{
    public class GenreController : Controller
    {
        private readonly MyMoviezDBContext _context;

        public GenreController(MyMoviezDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Genre> objgenresList = _context.Genres;
            return View(objgenresList);
        }

        //Get
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Genre genre)
        {
            if (ModelState.IsValid)
            {
                _context.Genres.Add(genre);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(genre);
        }

        public IActionResult Edit(int? GenreId)
        {
            if (GenreId == null || GenreId == 0)
            {
                return NotFound();
            }
            var genrefromDB = _context.Movies.Find(GenreId);
            if (genrefromDB == null)
            {
                return NotFound();
            }
            return View(genrefromDB);
        }

        //Post 
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Edit(Genre genre)
        {
            if (ModelState.IsValid)
            {
                _context.Genres.Update(genre);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(genre);
        }

        public IActionResult Delete(int? GenreId)
        {
            if (GenreId == null || GenreId == 0)
            {
                return NotFound();
            }
            var genrefromDB = _context.Movies.Find(GenreId);
            if (genrefromDB == null)
            {
                return NotFound();
            }
            return View(genrefromDB);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? GenreId)
        {
            var genre = _context.Movies.Find(GenreId);
            if (genre == null) { return NotFound(); }
            _context.Movies.Remove(genre);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
