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
      private readonly LapTimesContext _db = new LapTimesContext();

      private readonly ILapTimeRepository _repo;

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
            var racers = _db.Racers.Include(r => r.ClassName).Include(r => r.League);
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
          Racer racer = _db.Racers.Include(r => r.ClassName).Include(r => r.League).Single(r=> r.RacerId == id);
          
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
          ViewBag.ClassId = new SelectList(_db.ClassNames.OrderBy(c => c.Name), "ClassId", "Name");
            ViewBag.LeagueId = new SelectList(_db.Leagues, "LeagueId", "Name");
            return View();
        }

        //
        // POST: /ManageRacers/Racers/Create

        [HttpPost]
        public ActionResult Create(Racer racer)
        {
            if (ModelState.IsValid)
            {
                _db.Racers.Add(racer);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassId = new SelectList(_db.ClassNames.OrderBy(c => c.Name), "ClassId", "Name", racer.ClassId);
            ViewBag.LeagueId = new SelectList(_db.Leagues, "LeagueId", "Name", racer.LeagueId);
            return View(racer);
        }

        //
        // GET: /ManageRacers/Racers/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Racer racer = _db.Racers.Find(id);
            if (racer == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassId = new SelectList(_db.ClassNames.OrderBy(c => c.Name), "ClassId", "Name", racer.ClassId);
            ViewBag.LeagueId = new SelectList(_db.Leagues, "LeagueId", "Name", racer.LeagueId);
            return View(racer);
        }

        //
        // POST: /ManageRacers/Racers/Edit/5

        [HttpPost]
        public ActionResult Edit(Racer racer)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(racer).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassId = new SelectList(_db.ClassNames.OrderBy(c => c.Name), "ClassId", "Name", racer.ClassId);
            ViewBag.LeagueId = new SelectList(_db.Leagues, "LeagueId", "Name", racer.LeagueId);
            return View(racer);
        }

        //
        // GET: /ManageRacers/Racers/Delete/5

        public ActionResult Delete(int id = 0)
        {
          Racer racer = _db.Racers.Include(r => r.ClassName).Include(r => r.League).Single(r => r.RacerId == id);

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
            Racer racer = _db.Racers.Find(id);
            _db.Racers.Remove(racer);
            _db.SaveChanges();
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

      //
      // GET: /ManageRacers/Racers/GetRacersStartingWith/q/10
      public ActionResult GetUnpaidRacersStartingWith(string q, int limit)
      {

        if (!string.IsNullOrEmpty(q) && limit > 0)
        {
          // TODO: Caching?
          var racers =
            _repo.GetRacersStartingWith(q)
              .Where(r => !r.IsWaitingForRace)
              .Take(limit).AsEnumerable()
              .Select(
                r => new {id = r.RacerId, label = string.Format("{0} - {1}", r.Name, r.ClassName.Name), name = r.Name, classId = r.ClassId.ToString(), leagueId = r.LeagueId.ToString()});

          return Json(racers, JsonRequestBehavior.AllowGet);
        }

        return null;
      }


      protected override void Dispose(bool disposing)
      {
          _db.Dispose();
          base.Dispose(disposing);
      }
    }
}