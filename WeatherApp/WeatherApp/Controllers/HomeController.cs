using System;
using WeatherApp.Models;
using System.Linq;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;
using WeatherApp.ViewModels;

namespace WeatherApp.Controllers
{
  public class HomeController : Controller
  {
    //Data context para traer registros de la base de datos
    WeatherContext db = new WeatherContext();

    //Información acerca de los recursos utilizados para el presente proyecto
    public ActionResult About(int? userId)
    {
      if (Session["LoggedUser"] != null)
      {
        ViewBag.UserID = userId;
      }
      return View();
    }

    //Página principal. Si el usuario está logueado, también se manda a la vista el comentario del día
    public ActionResult Index(int? id)
    {
      if (Session["LoggedUser"] != null && id != null)
      {
        WeatherComment wcomment = db.WeatherComments.FirstOrDefault(p => p.DateComment == DateTime.Today);
        User user = db.Users.FirstOrDefault(p => p.ID == id);

        HomeViewModel UserVM = new HomeViewModel();
        UserVM.UserName = user.FirstName;
        
        var cities = db.UserCities.Where(u => u.UserID == id).ToList();
        ViewBag.User = user;
        ViewBag.WeatherComment = wcomment;
        ViewBag.UserCities = cities;
        return View(UserVM);
      }
      return View();
    }

    //Cuando el usuario está logueado puede enviar un correo al administrador del sitio    
    public ActionResult Contact(int userId)
    {
      if (Session["LoggedUser"] != null)
      {
        ViewBag.UserID = userId;
      }
      return View();
    }

    // Se envian los emails con los datos que completó el usuario. Uno al administrador y otro al mismo usuario
    [HttpPost]
    public ActionResult SendContactToAdministrator(string name, string email, string message)
    {
      ViewBag.Name = name;
      ViewBag.Mail = email;
      ViewBag.Message = message;

      SmtpClient SmtpClient = new SmtpClient("smtp.gmail.com", 587);
      SmtpClient.Credentials = new NetworkCredential("testcomunidadit@gmail.com", "testcomit2017");
      SmtpClient.EnableSsl = true;

      MailMessage emailToAdministrator = new MailMessage();
      emailToAdministrator.From = new MailAddress("testcomunidadit@gmail.com", "Test ComunidadIT");
      emailToAdministrator.To.Add("testcomunidadit@gmail.com");
      emailToAdministrator.Subject = "Nuevo contacto";
      emailToAdministrator.Body = "Te contactó: " + name + "(" + email + ").\nSu mensaje fue: " + message;

      SmtpClient.Send(emailToAdministrator);

      MailMessage emailToUser = new MailMessage();
      emailToUser.From = new MailAddress("testcomunidadit@gmail.com", "Test ComunidadIT");
      emailToUser.To.Add(email);
      emailToUser.Subject = "Gracias por contactarte con nosotros!";
      emailToUser.IsBodyHtml = true;
      emailToUser.Body = "Hola <b>" + name + "</b>!<br>Gracias por contactarte con nosotros!<br>Te responderemos a la brevedad.<br>Nos dejaste los siguientes datos:<br>Mail: " + email + "<br>Mensaje: " + message + "<br><br>Saludos!!!<br><b>La mejor APP</b><img src=\"https://www.rutanmedellin.org/media/zoo/images/ig_ahorro_energia_0a0cbcc8fa6bdf5eb09919f80f34d5dd.png\" />";

      SmtpClient.Send(emailToAdministrator);

      return View("Gracias");
    }
  }
}