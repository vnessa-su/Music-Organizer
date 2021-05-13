using Microsoft.AspNetCore.Mvc;
using MusicOrganizer.Models;
using System.Collections.Generic;

namespace MusicOrganizer.Controllers
{
  public class RecordsController : Controller
  {
    [HttpGet("/records")]
    public ActionResult Index()
    {
      List<string> allArtists = Record.GetArtists();
      return View(allArtists);
    }

    [HttpGet("/records/new")]
    public ActionResult New()
    {
      return View();
    }
  }
}