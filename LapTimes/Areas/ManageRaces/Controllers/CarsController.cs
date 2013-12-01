using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LapTimes.Models;

namespace LapTimes.Areas.ManageRaces.Controllers
{
    public class CarsController : Controller
    {
        private LapTimesContext db = new LapTimesContext();

        //
        // GET: /ManageRaces/Cars/

        public ActionResult Index()
        {
            return View(db.Cars.ToList());
        }

        //
        // GET: /ManageRaces/Cars/Details/5

        public ActionResult Details(int id = 0)
        {
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        //
        // GET: /ManageRaces/Cars/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /ManageRaces/Cars/Create

        [HttpPost]
        public ActionResult Create(Car car)
        {
            if (ModelState.IsValid)
            {
                db.Cars.Add(car);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(car);
        }

        //
        // GET: /ManageRaces/Cars/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        //
        // POST: /ManageRaces/Cars/Edit/5

        [HttpPost]
        public ActionResult Edit(Car car)
        {
            if (ModelState.IsValid)
            {
                db.Entry(car).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(car);
        }

        //
        // GET: /ManageRaces/Cars/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        //
        // POST: /ManageRaces/Cars/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Car car = db.Cars.Find(id);
            db.Cars.Remove(car);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}