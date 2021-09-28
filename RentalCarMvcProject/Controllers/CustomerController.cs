using RentalCarMvcProject.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentalCarMvcProject.Controllers
{
    public class CustomerController : Controller
    {
        RentalCarEntities db = new RentalCarEntities();
        public ActionResult Index()
        {
            var model = db.Customers.ToList();
            return View(model);
        }
        public ActionResult Yeni()
        {
            return View("Yeni");
        }

        public ActionResult Kaydet(Customers customers)
        {
            if (customers.Id == 0)
            {
                db.Customers.Add(customers);
            }
            else
            {
                var updatedEntity = db.Entry(customers);
                updatedEntity.State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Update(int id)
        {
            var updatedModel = db.Customers.Find(id);
            if (updatedModel == null)
            {
                return HttpNotFound();
            }

            return View("Yeni", updatedModel);
        }
        public ActionResult Delete(int id)
        {
            var deletedModel = db.Customers.Find(id);
            if (deletedModel == null)
            {
                return HttpNotFound();
            }
            db.Customers.Remove(deletedModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}