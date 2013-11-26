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
    public class RacersController : Controller
    {
        private LapTimesContainer db = new LapTimesContainer();

        //
        // GET: /ManageRacers/Racers/

        public ActionResult Index()
        {
            var racers = db.Racers.Include("ClassName").Include("League");
            return View(racers.ToList());
        }

        //
        // GET: /ManageRacers/Racers/Details/5

        public ActionResult Details(int id = 0)
        {
            Racer racer = db.Racers.Single(r => r.Id == id);
            if (racer == null)
            {
                return HttpNotFound();
            }
            return View(racer);
        }

        //
        // GET: /ManageRacers/Racers/Create

        public ActionResult Create()
        {
            ViewBag.ClassNameId = new SelectList(db.ClassNames, "Id", "Name");
            ViewBag.LeagueId = new SelectList(db.Leagues, "Id", "Name");
            return View();
        }

        //
        // POST: /ManageRacers/Racers/Create

        [HttpPost]
        public ActionResult Create(Racer racer)
        {
            if (ModelState.IsValid)
            {
                db.Racers.AddObject(racer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassNameId = new SelectList(db.ClassNames, "Id", "Name", racer.ClassNameId);
            ViewBag.LeagueId = new SelectList(db.Leagues, "Id", "Name", racer.LeagueId);
            return View(racer);
        }

        //
        // GET: /ManageRacers/Racers/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Racer racer = db.Racers.Single(r => r.Id == id);
            if (racer == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassNameId = new SelectList(db.ClassNames, "Id", "Name", racer.ClassNameId);
            ViewBag.LeagueId = new SelectList(db.Leagues, "Id", "Name", racer.LeagueId);
            return View(racer);
        }

        //
        // POST: /ManageRacers/Racers/Edit/5

        [HttpPost]
        public ActionResult Edit(Racer racer)
        {
            if (ModelState.IsValid)
            {
                db.Racers.Attach(racer);
                db.ObjectStateManager.ChangeObjectState(racer, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassNameId = new SelectList(db.ClassNames, "Id", "Name", racer.ClassNameId);
            ViewBag.LeagueId = new SelectList(db.Leagues, "Id", "Name", racer.LeagueId);
            return View(racer);
        }

        //
        // GET: /ManageRacers/Racers/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Racer racer = db.Racers.Single(r => r.Id == id);
            if (racer == null)
            {
                return HttpNotFound();
            }
            return View(racer);
        }

        //
        // POST: /ManageRacers/Racers/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Racer racer = db.Racers.Single(r => r.Id == id);
            db.Racers.DeleteObject(racer);
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