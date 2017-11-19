using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dotnet_new_mvc.Models;

namespace dotnet_new_mvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "La página de descripción de tu aplicación.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Tu página de contacto";

            return View();
        }

        
        public IActionResult BootstrapGrid()
        {
            ViewData["Message"] = "Página donde se practica el grid de Bootstrap";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
