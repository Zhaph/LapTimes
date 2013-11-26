﻿using System;
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
        private LapTimesContext db = new LapTimesContext();

        //
        // GET: /ManageRacers/Racers/

        public ActionResult Index()
        {
            var racers = db.Racers.Include(r => r.ClassName).Include(r => r.League);
            return View(racers.ToList());
        }

        //
        // GET: /ManageRacers/Racers/Details/5

        public ActionResult Details(int id = 0)
        {
            Racer racer = db.Racers.Find(id);
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
            ViewBag.ClassId = new SelectList(db.ClassNames, "ClassId", "Name");
            ViewBag.LeagueId = new SelectList(db.Leagues, "LeagueId", "Name");
            return View();
        }

        //
        // POST: /ManageRacers/Racers/Create

        [HttpPost]
        public ActionResult Create(Racer racer)
        {
            if (ModelState.IsValid)
            {
                db.Racers.Add(racer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassId = new SelectList(db.ClassNames, "ClassId", "Name", racer.ClassId);
            ViewBag.LeagueId = new SelectList(db.Leagues, "LeagueId", "Name", racer.LeagueId);
            return View(racer);
        }

        //
        // GET: /ManageRacers/Racers/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Racer racer = db.Racers.Find(id);
            if (racer == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassId = new SelectList(db.ClassNames, "ClassId", "Name", racer.ClassId);
            ViewBag.LeagueId = new SelectList(db.Leagues, "LeagueId", "Name", racer.LeagueId);
            return View(racer);
        }

        //
        // POST: /ManageRacers/Racers/Edit/5

        [HttpPost]
        public ActionResult Edit(Racer racer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(racer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassId = new SelectList(db.ClassNames, "ClassId", "Name", racer.ClassId);
            ViewBag.LeagueId = new SelectList(db.Leagues, "LeagueId", "Name", racer.LeagueId);
            return View(racer);
        }

        //
        // GET: /ManageRacers/Racers/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Racer racer = db.Racers.Find(id);
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
            Racer racer = db.Racers.Find(id);
            db.Racers.Remove(racer);
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