using EdusvKids.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EdusvKids.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Productos()
        {
            return View();
        }

        public IActionResult Monedas()
        {
            return View();
        }
        public IActionResult Descargar()
        {
            return View();
        }

        public IActionResult Pagar()
        {
            return View();
        }

        public IActionResult Cuenta()
        {
            return View();
        }

        public IActionResult Crear()
        {
            return View();
        }

        [Authorize]
        public IActionResult Vida()
        {
            return View();
        }

        public IActionResult Inicio()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}