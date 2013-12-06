using System.Collections.Generic;
using System.Linq;
using System.Web.Configuration;
using System.Web.Mvc;
using LapTimes.Models;

namespace LapTimes.Areas.ManageRaces.Controllers
{
    public class HomeController : Controller
    {
      private readonly LapTimesContext _db = new LapTimesContext();
      private readonly ILapTimeRepository _repo;

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
          ViewBag.NumberOfLanes = _numberOfLanes;
          ViewBag.CarId = new SelectList(_db.Cars.OrderBy(c => c.CarId), "CarId", "Name");
          var racers = _db.Racers.Where(r => r.IsWaitingForRace).OrderBy(c => c.Name).ToList();
          ViewBag.RacerId = new SelectList(racers, "RacerId", "Name");

          if (racers.Any() && racers.Take(2).Count() == 2)
          {
            // There are at least two racers waiting
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
                currentRace.Drivers.Add(new CurrentDriver {Lane = lane + 1});
              }
            }

            return View(currentRace);
          }

          return RedirectToAction("Index", "Home", new {Area = "ManageRacers"});
        }

      [HttpPost]
      public ActionResult Index(Race newRace)
      {
        if (ModelState.IsValid)
        {
          _db.Races.Add(newRace);
          _db.SaveChanges();
          return RedirectToAction("Index");
        }

        ViewBag.CarId = new SelectList(_db.Cars.OrderBy(c => c.CarId), "CarId", "Name");
        ViewBag.RacerId = new SelectList(_db.Racers.Where(r => r.IsWaitingForRace).OrderBy(c => c.Name), "RacerId",
                                         "Name");

        return View(newRace);
      }

    }
}
