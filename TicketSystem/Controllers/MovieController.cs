using Microsoft.AspNetCore.Mvc;
using TicketSystem.Services; 

namespace TicketSystem.Controllers
{
    public class MovieController : Controller
    {
        public async Task<IActionResult> Details(int id)
        {
            MovieService movieService = new MovieService();

            var movie = await movieService.GetMovieById(id);

            if(movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }
    }
}
