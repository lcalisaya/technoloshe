using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using t_ejercicio_heladeria_mvc_bootstrap.Models;

namespace t_ejercicio_heladeria_mvc_bootstrap.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Entregar calidad en los Productos y la mejor atención a nuestros Clientes es nuestro compromiso.";
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Client()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
