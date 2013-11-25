using System.Web.Mvc;

namespace LapTimes.Areas.ManageRaces
{
  public class ManageRacesAreaRegistration : AreaRegistration
  {
    public override string AreaName
    {
      get
      {
        return "ManageRaces";
      }
    }

    public override void RegisterArea(AreaRegistrationContext context)
    {
      context.MapRoute(
          "ManageRaces_default",
          "ManageRaces/{controller}/{action}/{id}",
          new { action = "Index", id = UrlParameter.Optional }
      );
    }
  }
}
