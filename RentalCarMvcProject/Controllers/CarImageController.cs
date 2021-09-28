using RentalCarMvcProject.Models.EntityFramework;
using RentalCarMvcProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentalCarMvcProject.Controllers
{
    public class CarImageController : Controller
    {
        RentalCarEntities db = new RentalCarEntities();
        public ActionResult Index()
        {
            var model = db.CarImages.ToList();
            return View(model);
        }
        public ActionResult Yeni()
        {
            var model = new CarImageViewModels() { 
            
             Car=db.Cars.ToList(),
              CarImages=new CarImages()
              

              
            
            };
            return View("Yeni", model);
        }
        [ValidateAntiForgeryToken]
        public ActionResult Kaydet(CarImages carImages)
        {
            if (!ModelState.IsValid)
            {
                var model = new CarImageViewModels()
                {

                    Car = db.Cars.ToList(),
                     CarImages=carImages
                

                };
                return View("Yeni", model);
            }
            if (carImages.Id == 0)
            {
                db.CarImages.Add(carImages);
            }
            else
            {
                var updatedEntity = db.Entry(carImages);
                updatedEntity.State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Update(int id)
        {
            var model = new CarImageViewModels()
            {

                Car = db.Cars.ToList(),
                 CarImages=db.CarImages.Find(id)

            };
            return View("Yeni", model);
        }
        public ActionResult Delete(int id)
        {
            var deletedModel = db.CarImages.Find(id);
            if (deletedModel == null)
            {
                return HttpNotFound();
            }
            db.CarImages.Remove(deletedModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}