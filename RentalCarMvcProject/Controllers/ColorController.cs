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
        public ActionResult Yeni()
        {
            return View("Yeni");
        }
        [ValidateAntiForgeryToken]
        public ActionResult Kaydet(Colors colors)
        {
            if (colors.ColorId == 0)
            {
                db.Colors.Add(colors);
            }
            else
            {
                var updatedEntity = db.Entry(colors);
                updatedEntity.State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Update(int id)
        {
            var updatedModel = db.Colors.Find(id);
            if (updatedModel == null)
            {
                return HttpNotFound();
            }
          
            return View("Yeni",updatedModel);
        }
        public ActionResult Delete(int id)
        {
            var deletedModel = db.Colors.Find(id);
            if (deletedModel == null)
            {
                return HttpNotFound();
            }
            db.Colors.Remove(deletedModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}