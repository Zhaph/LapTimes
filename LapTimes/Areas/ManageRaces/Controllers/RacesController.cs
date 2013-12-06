using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using LapTimes.Models;

namespace LapTimes.Areas.ManageRaces.Controllers
{
  public class RacesController : Controller
  {
    private readonly LapTimesContext _db = new LapTimesContext();

    private readonly ILapTimeRepository _repo;

    public RacesController(): this(new LapTimeRepository())
    {}

    public RacesController(ILapTimeRepository repo)
    {
      _repo = repo;
    }

    //
    // GET: /ManageRaces/Races/

    public ActionResult Index()
    {
      return View(_db.Races.Include(r => r.Drivers).Include("Drivers.Racer").Include("Drivers.Car").ToList());
    }

    //
    // GET: /ManageRaces/Races/Details/5

    public ActionResult Details(int id = 0)
    {
      Race race = _repo.GetRace(id);

      if (race == null)
      {
        return HttpNotFound();
      }

      return View(race);
    }

    //
    // GET: /ManageRaces/Races/Edit/5

    public ActionResult Edit(int id = 0)
    {
      Race race = _repo.GetRace(id);

      if (race == null)
      {
        return HttpNotFound();
      }
      
      return View(race);
    }

    //
    // POST: /ManageRaces/Races/Edit/5

    [HttpPost]
    public ActionResult Edit(Race race)
    {
      if (ModelState.IsValid)
      {
        _db.Entry(race).State = EntityState.Modified;
        _db.SaveChanges();

        return RedirectToAction("Index");
      }

      return View(race);
    }

    //
    // GET: /ManageRaces/Races/Delete/5

    public ActionResult Delete(int id = 0)
    {
      Race race = _repo.GetRace(id);

      if (race == null)
      {
        return HttpNotFound();
      }
      
      return View(race);
    }

    //
    // POST: /ManageRaces/Races/Delete/5

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      _repo.DeleteRace(id);

      return RedirectToAction("Index");
    }

    protected override void Dispose(bool disposing)
    {
      _db.Dispose();
      base.Dispose(disposing);
    }
  }
}