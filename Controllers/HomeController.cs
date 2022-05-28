using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Movie_App.Data;
using Movie_App.Models;
using System.Diagnostics;

namespace Movie_App.Controllers
{
    public class HomeController : Controller
    {
        private readonly MovieContext context;

        public HomeController(MovieContext context)
        {
            this.context = context;
        }

        void CONFIG()
        {
            var subTitles = new List<SelectListItem>
            {
                new SelectListItem { Text = "Khmer", Value = "Khmer" },
                new SelectListItem { Text = "English", Value = "English" },
                new SelectListItem { Text = "Japanese", Value = "Japanese" },
                new SelectListItem { Text = "Chinese", Value = "Chinese" },
            };

            var languages = new List<SelectListItem>
            {
                new SelectListItem { Text = "Khmer", Value = "Khmer" },
                new SelectListItem { Text = "English", Value = "English" },
                new SelectListItem { Text = "Japanese", Value = "Japanese" },
                new SelectListItem { Text = "Chinese", Value = "Chinese" },
            };

            var movieTypes = new List<SelectListItem>
            {
                new SelectListItem { Text = "Action", Value = "Action" },
                new SelectListItem { Text = "Horror", Value = "Horror" },
                new SelectListItem { Text = "Adventure", Value = "Adventure" },
                new SelectListItem { Text = "Comedy", Value = "Comedy" },
                new SelectListItem { Text = "Science", Value = "Science" },
            };

            ViewBag.SubTitles = subTitles;
            ViewBag.Languages = languages;
            ViewBag.MovieTypes = movieTypes;
        }

        public IActionResult Index()
        {
            var movies = context.Movies.ToList();

            return View(movies);
        }

        public IActionResult CreateMovie()
        {
            CONFIG();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateMovie(Movie model)
        {
            CONFIG();

            if (ModelState.IsValid)
            {
                context.Movies.Add(model);
                context.SaveChanges();

                TempData["SuccessMsg"] = "Create movie successfully.";
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult EditMovie(int? id)
        {
            CONFIG();

            var movie = context.Movies.Find(id);

            if(movie == null || movie.MovieId == 0)
            {
                return NotFound();
            }

            return View(movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditMovie(Movie model)
        {
            CONFIG();

            if (ModelState.IsValid)
            {
                context.Movies.Update(model);
                context.SaveChanges();

                TempData["SuccessMsg"] = "Create movie successfully.";
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult DeleteMovie(int? id)
        {
            var movie = context.Movies.Find(id);

            if (movie == null || movie.MovieId == 0)
            {
                return NotFound();
            }

            return View(movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RemoveMovie(int? id)
        {
            var data = context.Movies.Find(id);

            if (data == null)
            {
                NotFound();
            }

            context.Movies.Remove(data);
            context.SaveChanges();

            TempData["SuccessMsg"] = "Remove movie successfully.";
            return RedirectToAction("Index");
        }
    }
}