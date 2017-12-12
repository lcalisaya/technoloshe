using Technoloshe20173CSeriesMVC.Models;
using System.Linq;
using System.Web.Mvc;


namespace Technoloshe20173CSeriesMVC.Controllers
{
    public class UsersController : Controller
    {
        private SeriesContext db = new SeriesContext(); //creamos el contexto para poder laburar con la bd

        /// <summary>
        /// mostramos la vista de login
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// Recibimos los datos del formulario de login y
        /// validamos que exista el usuario y coincida la contraseña.
        /// </summary>
        /// <param name="mail"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DoLogin(string mail, string password)
        {
            //buscamos al usuario
            User user = db.Users.FirstOrDefault(u => u.Mail.Equals(mail));
            if (user != null && user.Password.Equals(password)) //si existe (no queda null) y la contraseña coincide
            {
                Session["LoggedUser"] = user; //agregamos el objeto usuario a la sesión, para después tener control sobre él
                return RedirectToAction("Index", "Series");
            }
            //si no existe el usuario o la contraseña no coincide
            return RedirectToAction("Login", "Users");
        }
    }
}
