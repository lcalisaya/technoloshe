using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MvcMovieCore.Controllers
{
    public class HelloWorldController : Controller
    {
        // 
        // GET: /HelloWorld/

        public string Index()
        {
            return "Esta es mi acción predeterminada...";
        }

        // GET: /HelloWorld/Welcome/ 
        // Requires using System.Text.Encodings.Web;

        // Se asigna automáticamente los parámetros nombrados en la cadena de consulta (Query string)
        // que fueron enviados por la barra de direcciones, a los parámetros del método

        // Si no se pasan valores en la URL, los parámetros se llenan con "María" y 1.
        public string Welcome(string name = "sin nombre", int numTimes = 1)
        {
            // Interpolación de string = "Hola {variableName}"
            return HtmlEncoder.Default.Encode($"Hola {name}, numTimes es: {numTimes}");
        }

        public string WelcomeTwo(string name, int ID = 1)
        {
            return HtmlEncoder.Default.Encode($"Hola {name}, ID: {ID}");
        }
    }
}
