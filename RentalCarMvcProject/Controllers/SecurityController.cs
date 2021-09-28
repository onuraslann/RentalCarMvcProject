using RentalCarMvcProject.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace RentalCarMvcProject.Controllers
{
   
    public class SecurityController : Controller
    {
        RentalCarEntities db = new RentalCarEntities();
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(Userss userss)
        {
            var user = db.Userss.FirstOrDefault(x => x.Name == userss.Name && x.Password == userss.Password);
            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(user.Name, false);
                return RedirectToAction("Index", "Car");
            }
            else
            {
                ViewBag.Mesaj = "Giriş başarısız";
                return View();
            }
            
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}