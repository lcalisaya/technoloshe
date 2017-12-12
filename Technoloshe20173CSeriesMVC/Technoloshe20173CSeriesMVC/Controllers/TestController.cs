using Technoloshe20173CSeriesMVC.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Technoloshe20173CSeriesMVC.Controllers
{
    public class TestController : Controller
    {
        SeriesContext db = new SeriesContext();

        // GET: Test
        public ActionResult AddUser(string mail, string password)
        {
            User newUser = new User();
            newUser.Mail = mail;
            newUser.Password = password;

            db.Users.Add(newUser);
            db.SaveChanges();

            return Json(newUser, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddFavourite(string userMail, int serieID)
        {
            User user = db.Users.Include("Favourites").FirstOrDefault(u => u.Mail.Equals(userMail));
            Serie serie = db.Series.FirstOrDefault(s => s.ID == serieID);

            if (user != null && serie != null)
            {
                if (user.Favourites == null)
                    user.Favourites = new List<Serie>();
                user.Favourites.Add(serie);
                db.SaveChanges();
            }

            return Json(user, JsonRequestBehavior.AllowGet);
        }
    }
}
