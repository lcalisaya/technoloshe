using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MvcMovieCore.Controllers
{
    // Los controladores son responsables de proporcionar los datos requeridos para que una plantilla de visualización (vista) presente una respuesta
    public class HelloWorldController : Controller
    {
        // 
        // GET: /HelloWorld/
        // métodos del controlador == métodos acción
        public IActionResult Index()
        {
            return View();
        }

        // El objeto diccionario ViewData contiene datos que se pasarán desde el controlador a la vista
        public IActionResult Welcome(string name, int numTimes = 1)
        {
            ViewData["Message"] = "Hola " + name;
            ViewData["NumTimes"] = numTimes;

            return View();
        }
    }
}
