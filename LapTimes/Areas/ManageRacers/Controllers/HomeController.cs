using System.Data;
using System.Linq;
using System.Web.Mvc;
using LapTimes.Models;

namespace LapTimes.Areas.ManageRacers.Controllers
{
    public class HomeController : Controller
    {
      private LapTimesContext db = new LapTimesContext();

      //
      // GET: /ManageRacers/Home/

      public ActionResult Index()
      {
        ViewBag.ClassId = new SelectList(db.ClassNames.OrderBy(c => c.Name), "ClassId", "Name");
        ViewBag.LeagueId = new SelectList(db.Leagues, "LeagueId", "Name");
        ViewBag.AtLeastTwoRacers = db.Racers.Where(r => r.IsWaitingForRace).Take(2).Count() == 2;

        return View(new Racer{RacerId = 0});
      }

      [HttpPost]
      public ActionResult Index(Racer racer)
      {
        if (racer.RacerId == 0)
        {
          if (ModelState.IsValid)
          {
            racer.IsWaitingForRace = true;
            db.Racers.Add(racer);
            db.SaveChanges();
            return RedirectToAction("Index");
          }

          ViewBag.ClassId = new SelectList(db.ClassNames.OrderBy(c => c.Name), "ClassId", "Name", racer.ClassId);
          ViewBag.LeagueId = new SelectList(db.Leagues, "LeagueId", "Name", racer.LeagueId);
          return View(racer);
        }

        Racer foundRacer = db.Racers.Find(racer.RacerId);
        foundRacer.IsWaitingForRace = true;
        db.Entry(foundRacer).State = EntityState.Modified;
        db.SaveChanges();
        return RedirectToAction("Index");
      }
    }
}
