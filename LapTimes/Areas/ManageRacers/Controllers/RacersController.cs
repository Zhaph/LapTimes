using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using LapTimes.Areas.ManageRacers.Models;
using LapTimes.Models;

namespace LapTimes.Areas.ManageRacers.Controllers
{
    public class RacersController : Controller
    {
      private LapTimesContext db = new LapTimesContext();

      private ILapTimeRepository _repo;

      public RacersController(): this(new LapTimeRepository())
      {}

      public RacersController(ILapTimeRepository repo)
      {
        _repo = repo;
      }

      //
        // GET: /ManageRacers/Racers/

        public ActionResult Index()
        {
            var racers = db.Racers.Include(r => r.ClassName).Include(r => r.League);
            return View(new RacersHomeModel {Filter = string.Empty, Racers = racers});
        }

      [HttpPost]
      public ActionResult Index(string filter)
      {
        if (!string.IsNullOrEmpty(filter))
        {
          var racers = _repo.GetRacersStartingWith(filter);

          return View(new RacersHomeModel {Filter = filter, Racers = racers});
        }

        return RedirectToAction("Index");
      }

        //
        // GET: /ManageRacers/Racers/Details/5

        public ActionResult Details(int id = 0)
        {
          Racer racer = db.Racers.Include(r => r.ClassName).Include(r => r.League).Single(r=> r.RacerId == id);
          
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
          ViewBag.ClassId = new SelectList(db.ClassNames.OrderBy(c => c.Name), "ClassId", "Name");
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

            ViewBag.ClassId = new SelectList(db.ClassNames.OrderBy(c => c.Name), "ClassId", "Name", racer.ClassId);
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
            ViewBag.ClassId = new SelectList(db.ClassNames.OrderBy(c => c.Name), "ClassId", "Name", racer.ClassId);
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
            ViewBag.ClassId = new SelectList(db.ClassNames.OrderBy(c => c.Name), "ClassId", "Name", racer.ClassId);
            ViewBag.LeagueId = new SelectList(db.Leagues, "LeagueId", "Name", racer.LeagueId);
            return View(racer);
        }

        //
        // GET: /ManageRacers/Racers/Delete/5

        public ActionResult Delete(int id = 0)
        {
          Racer racer = db.Racers.Include(r => r.ClassName).Include(r => r.League).Single(r => r.RacerId == id);

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

      //
      // GET: /ManageRacers/Racers/GetRacersStartingWith/q/10
      public ActionResult GetRacersStartingWith(string q, int limit)
      {

        if (!string.IsNullOrEmpty(q) && limit > 0)
        {
          // TODO: Caching?
          var racers = _repo.GetRacersStartingWith(q).Take(limit).Select(r => new {id = r.RacerId, label= r.Name, name = r.Name});

          return Json(racers, JsonRequestBehavior.AllowGet);
        }

        return null;
      }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}