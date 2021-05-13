using Microsoft.AspNetCore.Mvc;

namespace MusicOrganizer.Controllers
{
  public class HomeController : Controllers
  {
    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }
  }
}