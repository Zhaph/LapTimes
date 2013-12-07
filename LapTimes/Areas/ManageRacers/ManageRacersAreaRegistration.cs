using System.Web.Mvc;

namespace LapTimes.Areas.ManageRacers
{
  public class ManageRacersAreaRegistration : AreaRegistration
  {
    public override string AreaName
    {
      get
      {
        return "ManageRacers";
      }
    }

    public override void RegisterArea(AreaRegistrationContext context)
    {
      context.MapRoute(
        "ManageRacers_Racers_GetUnpaidRacersStartingWith",
        "ManageRacers/{controller}/{action}/{q}/{limit}",
        new { controller = "Racers" }
        );

      context.MapRoute(
        "ManageRacers_Racers_GetRacersStartingWith",
        "ManageRacers/{controller}/{action}/{q}/{limit}",
        new {controller = "Racers"}
        );

      context.MapRoute(
          "ManageRacers_default",
          "ManageRacers/{controller}/{action}/{id}",
          new { action = "Index", id = UrlParameter.Optional }
      );
    }
  }
}
