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

    [HttpPost("/records")]
    public ActionResult Create(string newRecord, string newArtist)
    {
      Record firstRecord = new Record(newRecord, newArtist);
      return RedirectToAction("Index");
    }

    [HttpGet("/records/{artist}")]
    public ActionResult Show(string artist)
    {
      List<Record> recordsByArtist = Record.GetAllByArtist(artist);
      return View(recordsByArtist);
    }

    [HttpPost("records/delete/{recordId}")]
    public ActionResult Delete(int recordId)
    {
      record.DeleteRecord();
      return ReDirectToAction("Index");
    }
  }
}