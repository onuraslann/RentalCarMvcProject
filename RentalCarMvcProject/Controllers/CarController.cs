using RentalCarMvcProject.Models.EntityFramework;
using RentalCarMvcProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentalCarMvcProject.Controllers
{
    public class CarController : Controller
    {
        RentalCarEntities db = new RentalCarEntities();
        public ActionResult Index()
        {
            var model = db.Cars.ToList();
            return View(model);
        }
        public ActionResult Yeni()
        {
            
            var model = new CarViewModels()
            {
                 Brands=db.Brands.ToList(),
                  Colors=db.Colors.ToList(),
                   Cars=new Cars()

            };
            return View("Yeni", model);
        }
        [ValidateAntiForgeryToken]
        public ActionResult Kaydet(Cars cars)
        {
            if (!ModelState.IsValid)
            {
                var model = new CarViewModels()
                {
                    Brands = db.Brands.ToList(),
                    Colors = db.Colors.ToList(),
                    Cars=cars

                };
                return View("Yeni", model);
            }
            if (cars.Id == 0)
            {
                db.Cars.Add(cars);
            }
            else
            {
                var updatedEntity = db.Entry(cars);
                updatedEntity.State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        
        }
        public ActionResult Update(int id)
        {
            var model = new CarViewModels()
            {
                Brands = db.Brands.ToList(),
                Colors = db.Colors.ToList(),
                Cars=db.Cars.Find(id)

            };
            return View("Yeni", model);

        }
        public ActionResult Delete(int id)
        {
            var deletedModel = db.Cars.Find(id);
            if (deletedModel == null)
            {
                return HttpNotFound();
            }
            db.Cars.Remove(deletedModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}