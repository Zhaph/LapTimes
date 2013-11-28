using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LapTimes.Models;

namespace LapTimes.Controllers
{
  public class HomeController : Controller
  {
    private readonly ILapTimeRepository _lapRepo;

    public HomeController(): this (new LapTimeRepository())
    {
    }

    public HomeController(ILapTimeRepository lapRepo)
    {
      _lapRepo = lapRepo;
    }

    public ActionResult Index()
    {
      ViewBag.Message = "Waiting for a race to begin...";

      ViewBag.Leagues = _lapRepo.GetCurrentLeaderBoards();

      return View();
    }

    public ActionResult About()
    {
      ViewBag.Message = "Your app description page.";

      return View();
    }

    public ActionResult Contact()
    {
      ViewBag.Message = "Your contact page.";

      return View();
    }
  }
}
