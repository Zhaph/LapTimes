using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LapTimes.Models;

namespace LapTimes.Areas.ManageRacers.Controllers
{
    public class ClassesController : Controller
    {
        private LapTimesContext db = new LapTimesContext();

        //
        // GET: /ManageRacers/Classes/

        public ActionResult Index()
        {
            return View(db.ClassNames.OrderBy(c => c.Name).ToList());
        }

        //
        // GET: /ManageRacers/Classes/Details/5

        public ActionResult Details(int id = 0)
        {
            ClassName classname = db.ClassNames.Find(id);
            if (classname == null)
            {
                return HttpNotFound();
            }
            return View(classname);
        }

        //
        // GET: /ManageRacers/Classes/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /ManageRacers/Classes/Create

        [HttpPost]
        public ActionResult Create(ClassName classname)
        {
            if (ModelState.IsValid)
            {
                db.ClassNames.Add(classname);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(classname);
        }

        //
        // GET: /ManageRacers/Classes/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ClassName classname = db.ClassNames.Find(id);
            if (classname == null)
            {
                return HttpNotFound();
            }
            return View(classname);
        }

        //
        // POST: /ManageRacers/Classes/Edit/5

        [HttpPost]
        public ActionResult Edit(ClassName classname)
        {
            if (ModelState.IsValid)
            {
                db.Entry(classname).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(classname);
        }

        //
        // GET: /ManageRacers/Classes/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ClassName classname = db.ClassNames.Find(id);
            if (classname == null)
            {
                return HttpNotFound();
            }
            return View(classname);
        }

        //
        // POST: /ManageRacers/Classes/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            ClassName classname = db.ClassNames.Find(id);
            db.ClassNames.Remove(classname);
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