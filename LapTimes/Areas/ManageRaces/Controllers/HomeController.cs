using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using LapTimes.Models;

namespace LapTimes.Areas.ManageRaces.Controllers
{
    public class HomeController : Controller
    {
      private LapTimesContext db = new LapTimesContext();

      private int _numberOfLanes = int.Parse(WebConfigurationManager.AppSettings["RaceLanes"]);
      
        //
        // GET: /ManageRaces/Home/

        public ActionResult Index()
        {
          ViewBag.CarId = new SelectList(db.Cars.OrderBy(c => c.CarId), "CarId", "Name");
          ViewBag.RacerId = new SelectList(db.Racers.Where(r => r.IsWaitingForRace).OrderBy(c => c.Name), "RacerId",
                                           "Name");
          ViewBag.NumberOfLanes = _numberOfLanes;

          var currentRace = db.Races.Where(r => !r.IsComplete).SingleOrDefault();

          return View(currentRace);
        }

      [HttpPost]
      public ActionResult Index(Race newRace)
      {
        if (ModelState.IsValid)
        {
          
        }

        ViewBag.CarId = new SelectList(db.Cars.OrderBy(c => c.CarId), "CarId", "Name");
        ViewBag.RacerId = new SelectList(db.Racers.Where(r => r.IsWaitingForRace).OrderBy(c => c.Name), "RacerId",
                                         "Name");

        return View(newRace);
      }

    }
}
