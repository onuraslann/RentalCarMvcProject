using RentalCarMvcProject.Models.EntityFramework;
using RentalCarMvcProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentalCarMvcProject.Controllers
{
    public class RentalController : Controller
    {
        RentalCarEntities db = new RentalCarEntities();
        public ActionResult Index()
        {
            var model = db.Rentals.ToList();
            return View(model);
        }
        public ActionResult Yeni()
        {
            var model = new RentalViewModels() { 
             Cars=db.Cars.ToList(),
              Customers=db.Customers.ToList(),
               Rentals=new Rentals()
            
            };
            return View("Yeni", model);
        }
        public ActionResult Kaydet(Rentals rentals)
        {
            if (!ModelState.IsValid)
            {
                var model = new RentalViewModels()
                {
                    Cars = db.Cars.ToList(),
                    Customers = db.Customers.ToList(),
                    Rentals = rentals

                };
                return View("Yeni", model);
            
        }
            if (rentals.Id == 0)
            {
                db.Rentals.Add(rentals);

            }
            else
            {
                var updatedEntity = db.Entry(rentals);
                updatedEntity.State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Update(int id)
        {
            var model = new RentalViewModels()
            {
                Cars = db.Cars.ToList(),
                Customers = db.Customers.ToList(),
                 Rentals=db.Rentals.Find(id)

            };
            return View("Yeni", model);

        }
        public ActionResult Delete(int id)
        {
            var updatedEntity = db.Rentals.Find(id);
            if (updatedEntity == null)
            {
                return HttpNotFound();
            }
            db.Rentals.Remove(updatedEntity);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}