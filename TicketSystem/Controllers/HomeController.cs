using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TicketSystem.Models;
using TicketSystem.DTOs;
using TicketSystem.Validations;
using TicketSystem.Services; 

namespace TicketSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Usuarios _usuarios; 

        public HomeController(ILogger<HomeController> logger, Usuarios usuarios)
        {
            _logger = logger;
            _usuarios = usuarios;
        }

        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LogIn(Login usuario)
        {
            if(!ModelState.IsValid) {
                return View(usuario); 
            } else
            {

                foreach(Usuario user in _usuarios.lista_usuarios)
                {
                    if(usuario.nombre_usuario == user.nombre_usuario && usuario.password == user.password)
                    {
                        HttpContext.Session.SetString("userName", user.nombre);
                        HttpContext.Session.SetString("userRole",user.isAdmin.ToString());
                        return RedirectToAction("Index", "Home"); 
                    }
                }

                ViewBag.Error = "El usuario indicado no existe";
                return View();
            }

        }

        [ValidateLogin]
        public async Task<IActionResult> Index()
        {

            MovieService movieService = new MovieService();
            var movies = await movieService.GetMovies();

            return View(movies);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        [ValidateLogin]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}