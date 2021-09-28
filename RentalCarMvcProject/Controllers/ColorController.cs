using RentalCarMvcProject.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentalCarMvcProject.Controllers
{
    public class ColorController : Controller
    {
        RentalCarEntities db = new RentalCarEntities();
        public ActionResult Index()
        {
            var model = db.Colors.ToList();
            return View(model);
        }
    }
}