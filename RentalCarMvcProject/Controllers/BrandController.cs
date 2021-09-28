using RentalCarMvcProject.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentalCarMvcProject.Controllers
{
    public class BrandController : Controller
    {
        RentalCarEntities db = new RentalCarEntities();
        public ActionResult Index()
        {
            var model = db.Brands.ToList();
            return View(model);
        }

        public ActionResult Yeni()
        {
            return View("Yeni",new Brands());
        }
        [ValidateAntiForgeryToken]
        public ActionResult Kaydet(Brands brands)
        {
            if (!ModelState.IsValid)
            {
                return View("Yeni");
            }
            if (brands.BrandId == 0)
            {
                db.Brands.Add(brands);
            }
            else
            {
                var updatedEntity = db.Entry(brands);
                updatedEntity.State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Update(int id)
        {
            var updatedModel = db.Brands.Find(id);
            if (updatedModel == null)
            {
                return HttpNotFound();
            }

            return View("Yeni", updatedModel);
        }
        public ActionResult Delete(int id)
        {
            var deletedModel = db.Brands.Find(id);
            if (deletedModel == null)
            {
                return HttpNotFound();
            }
            db.Brands.Remove(deletedModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}