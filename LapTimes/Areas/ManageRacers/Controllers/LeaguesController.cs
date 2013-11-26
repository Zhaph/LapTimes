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
    public class LeaguesController : Controller
    {
        private LapTimesContext db = new LapTimesContext();

        //
        // GET: /ManageRacers/Leagues/

        public ActionResult Index()
        {
            return View(db.Leagues.ToList());
        }

        //
        // GET: /ManageRacers/Leagues/Details/5

        public ActionResult Details(int id = 0)
        {
            League league = db.Leagues.Find(id);
            if (league == null)
            {
                return HttpNotFound();
            }
            return View(league);
        }

        //
        // GET: /ManageRacers/Leagues/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /ManageRacers/Leagues/Create

        [HttpPost]
        public ActionResult Create(League league)
        {
            if (ModelState.IsValid)
            {
                db.Leagues.Add(league);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(league);
        }

        //
        // GET: /ManageRacers/Leagues/Edit/5

        public ActionResult Edit(int id = 0)
        {
            League league = db.Leagues.Find(id);
            if (league == null)
            {
                return HttpNotFound();
            }
            return View(league);
        }

        //
        // POST: /ManageRacers/Leagues/Edit/5

        [HttpPost]
        public ActionResult Edit(League league)
        {
            if (ModelState.IsValid)
            {
                db.Entry(league).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(league);
        }

        //
        // GET: /ManageRacers/Leagues/Delete/5

        public ActionResult Delete(int id = 0)
        {
            League league = db.Leagues.Find(id);
            if (league == null)
            {
                return HttpNotFound();
            }
            return View(league);
        }

        //
        // POST: /ManageRacers/Leagues/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            League league = db.Leagues.Find(id);
            db.Leagues.Remove(league);
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