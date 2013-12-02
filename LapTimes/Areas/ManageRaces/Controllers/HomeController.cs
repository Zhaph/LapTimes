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
      private ILapTimeRepository _repo;

      public HomeController(): this(new LapTimeRepository())
      {}

      public HomeController(ILapTimeRepository repo)
      {
        _repo = repo;
      }

      private int _numberOfLanes = int.Parse(WebConfigurationManager.AppSettings["RaceLanes"]);
      
        //
        // GET: /ManageRaces/Home/

        public ActionResult Index()
        {
          ViewBag.CarId = new SelectList(db.Cars.OrderBy(c => c.CarId), "CarId", "Name");
          ViewBag.RacerId = new SelectList(db.Racers.Where(r => r.IsWaitingForRace).OrderBy(c => c.Name), "RacerId",
                                           "Name");
          ViewBag.NumberOfLanes = _numberOfLanes;

          var currentRace = _repo.CurrentRace() ??
                            new Race
                              {
                                RaceId = 0,
                                Drivers =
                                  new List<CurrentDriver>(_numberOfLanes)
                              };

          if (currentRace.RaceId == 0)
          {
            for (int lane = 0; lane < _numberOfLanes; lane++)
            {
              currentRace.Drivers.Add(new CurrentDriver{Lane = lane + 1});
            }
          }

          return View(currentRace);
        }

      [HttpPost]
      public ActionResult Index(Race newRace)
      {
        if (ModelState.IsValid)
        {
          db.Races.Add(newRace);
          db.SaveChanges();
          return RedirectToAction("Index");
        }

        ViewBag.CarId = new SelectList(db.Cars.OrderBy(c => c.CarId), "CarId", "Name");
        ViewBag.RacerId = new SelectList(db.Racers.Where(r => r.IsWaitingForRace).OrderBy(c => c.Name), "RacerId",
                                         "Name");

        return View(newRace);
      }

    }
}
