using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WeatherApp.Models;
using System;

namespace WeatherApp.Controllers
{

  public static class Json
  {
  }

  public class UserController : Controller
  {
    //Data context para traer registros de la base de datos
    WeatherContext db = new WeatherContext();

    //Se muestra el formulario de registro de usuarios
    public ActionResult SignUp()
    {
      return View();
    }

    //Se guardan los datos del usuario que solicitó crear una cuenta
    [HttpPost]
    public ActionResult SignUp(string firstName, string lastName, string pass, string email)
    {
      User user = db.Users.FirstOrDefault(u => u.Email.Equals(email));
      if (user != null)
      {
        TempData["message"] = "El email ingresado pertenece a una cuenta ya existente. Intente registrarse con otro email";
        return RedirectToAction("SignUp", "User");
      }
      else
      {
        User newUser = new User();
        newUser.FirstName = firstName;
        newUser.LastName = lastName;
        newUser.Password = pass;
        newUser.Email = email;

        db.Users.Add(newUser);
        db.SaveChanges();

        TempData["message"] = "Se ha registrado a Weather App! Muchas gracias! A continuación inicie sesión:";
        return RedirectToAction("Login", "User");
      }
    }

    //Se enviará la vista que devuelve el formulario de login
    public ActionResult Login()
    {
      return View();
    }

    //Se verifica que el usuario que indicó un correo haya ingresado la contraseña que corresponde
    [HttpPost]
    public ActionResult DoLogin(string email, string pass)
    {
      User user = db.Users.FirstOrDefault(u => u.Email.Equals(email));
      if (user != null && user.Password.Equals(pass))
      {
        Session["LoggedUser"] = user;
        TempData["Message"] = "Ha iniciado su sesión";
        return RedirectToAction("Index", "Home", new { id = user.ID });
      }
      else
      {
        ViewBag.Message = "Datos incorrectos. Intente loguearse otra vez.";
        return View("Login");
      }
    }

    //Se recibe el voto del usuario que votó en la encuesta del día
    [HttpPost]
    public ActionResult UserVote(int interesting, string userID, string commentID)
    {
      int userIDInteger = Int32.Parse(userID);
      int commentIDInteger = Int32.Parse(commentID);
      Voting voting = db.UserVotes.Where(i => i.UserID == userIDInteger && i.WeatherCommentID == commentIDInteger).FirstOrDefault();
      if (voting == null)
      {
        Voting newvote = new Voting();
        newvote.UserID = Int32.Parse(userID);
        newvote.WeatherCommentID = Int32.Parse(commentID);
        newvote.Vote = Convert.ToBoolean(interesting);
        db.UserVotes.Add(newvote);
        db.SaveChanges();
        TempData["Message"] = "Gracias por haber votado! Los resultados se publicarán a fin de mes.";
      }
      else
      {
        TempData["Message"] = "Usted ya votó! No puede volver a votar.";
      }
      return RedirectToAction("Index", "Home", new { id = userIDInteger });
    }

    //El usuario cierra sesión
    public ActionResult Logout()
    {
      Session["LoggedUser"] = null;
      TempData["Message"] = "Ha cerrado su sesión!";

      return RedirectToAction("Index", "Home");
    }

    //El usuario agrega una ciudad a su lista de ciudades
    public ActionResult AddUserCity(string cityName, string userID)
    {
      int userIDInt = Int32.Parse(userID);
      UserCity cityAlreadySaved = db.UserCities.Where(i => i.UserID == userIDInt && i.Location == cityName).FirstOrDefault();
      if (cityAlreadySaved != null)
      {
        UserCity userCity = new UserCity { UserID = Int32.Parse(userID), Location = cityName };
        db.UserCities.Add(userCity);
        db.SaveChanges();
        return Json(new { message = "ok" });
      }
      else {
        return Json(new { message = "error" });
      }
    }

    //Se muestran todas las ciudades guardadas por ese usuario
    public ActionResult IndexUserCities(int userId)
    {
      List<UserCity> userCitiesList = db.UserCities.Where(i => i.UserID == userId).ToList();
      if (userCitiesList != null)
      {
        ViewBag.UserCities = userCitiesList;
        ViewBag.UserID = userId;
      }
      else
      {
        ViewBag.Message = "Usted aún no ha guardado ninguna ciudad.";
      }
      return View();
    }

    //Se elimina una ciudad de la lista de ciudades del usuario
    public ActionResult RemoveUserCity(string location, string userID)
    {
      int IntUserID = Int32.Parse(userID);
      UserCity userCity = db.UserCities.Where(i => i.UserID == IntUserID && i.Location == location).FirstOrDefault();

      db.UserCities.Remove(userCity);
      db.SaveChanges();
      
      return Json(new { removelocation = location });
    }
  }
}