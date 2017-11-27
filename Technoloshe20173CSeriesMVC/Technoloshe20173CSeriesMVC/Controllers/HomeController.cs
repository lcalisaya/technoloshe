using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace SeriesApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contacto()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult RecibirContacto(string nombre,
                                string mail, string mensaje)
        {
            //return RedirectToAction("Index", "Home");
            ViewBag.Nombre = nombre;
            ViewBag.Mail = mail;
            ViewBag.Mensaje = mensaje;

            //Definimos la conexión al servidor SMTP que vamos a usar
            //para mandar el mail. Hay que buscar como es en nuestro proveedor.
            SmtpClient clienteSmtp = new SmtpClient("smtp.gmail.com", 587);
            clienteSmtp.Credentials = new NetworkCredential("testcomunidadit@gmail.com", "testcomit2017");
            clienteSmtp.EnableSsl = true;

            //Generamos el objeto MAIL a enviar
            MailMessage mailParaAdministrador = new MailMessage();
            mailParaAdministrador.From = new MailAddress("testcomunidadit@gmail.com", "Test ComunidadIT");
            mailParaAdministrador.To.Add("testcomunidadit@gmail.com");
            mailParaAdministrador.Subject = "Nuevo contacto";
            mailParaAdministrador.Body = "Te contactó: " + nombre + "(" + mail + ").\nSu mensaje fue: " + mensaje;

            //mandamos el mail
            clienteSmtp.Send(mailParaAdministrador);

            //vamos a mandarle un mail al usuario que nos dejó el contacto
            MailMessage mailAUsuario = new MailMessage();
            mailAUsuario.From = new MailAddress("testcomunidadit@gmail.com", "Test ComunidadIT");
            mailAUsuario.To.Add(mail);
            mailAUsuario.Subject = "Gracias por contactarte con nosotros!";
            mailAUsuario.IsBodyHtml = true;
            mailAUsuario.Body = "Hola <b>" + nombre + "</b>!<br>Gracias por contactarte con nosotros!<br>Te responderemos a la brevedad.<br>Nos dejaste los siguientes datos:<br>Mail: " + mail + "<br>Mensaje: " + mensaje + "<br><br>Saludos!!!<br><b>La mejor APP</b><img src=\"https://maspublicidades.com/wp-content/uploads/2017/03/contacto.jpg\" />";

            //usamos el mismo objeto cliente smtp que creamos antes
            clienteSmtp.Send(mailAUsuario);

            return View("Gracias");
        }
    }
}