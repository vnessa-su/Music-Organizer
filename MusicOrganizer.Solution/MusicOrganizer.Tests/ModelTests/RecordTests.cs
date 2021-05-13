using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicOrganizer.Models;
using System.Collections.Generic;
using System;

namespace MusicOrganizer.Tests
{
  [TestClass]
  public class RecordTests : IDisposable
  {
    public void Dispose()
    {
      Record.ClearAll();
    }

    [TestMethod]
    public void RecordConstructor_CreateInstanceOfRecord_Record()
    {
      Record newRecord = new Record("Thrust", "Herbie Hancock");
      Assert.AreEqual(typeof(Record), newRecord.GetType());
    }

    [TestMethod]
    public void GetRecordTitle_ReturnRecordTitle_String()
    {
      string recordTitle = "Thrust";
      string recordArtist = "Herbie Hancock";

      Record newRecord = new Record(recordTitle, recordArtist);
      string result = newRecord.Title;

      Assert.AreEqual(recordTitle, result);

    }

    [TestMethod]
    public void GetAll_ReturnsEmptyList_recordTitles()
    {
      List<Record> newList = new List<Record> { };

      List<Record> result = Record.GetAll();

      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetAll_ReturnsRecords_recordTitles()
    {
      string recordTitle1 = "Thrust";
      string recordArtist = "Herbie Hancock";
      string recordTitle2 = "Save Me";
      string recordArtist2 = "Jenny Hancock";

      Record newRecord1 = new Record(recordTitle1, recordArtist);
      Record newRecord2 = new Record(recordTitle2, recordArtist2);
      List<Record> newList = new List<Record> { newRecord1, newRecord2 };

      List<Record> result = Record.GetAll();

      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Find_ReturnsAccurateRecord_Record()
    {
      string recordTitle1 = "Thrust";
      string recordArtist = "Herbie Hancock";
      string recordTitle2 = "Save Me";
      string recordArtist2 = "Jenny Hancock";

      Record newRecord1 = new Record(recordTitle1, recordArtist);
      Record newRecord2 = new Record(recordTitle2, recordArtist2);

      Record result = Record.Find(2);

      Assert.AreEqual(newRecord2, result);
    }

    [TestMethod]
    public void GetAllByArtist_JennyHancock_TwoRecords()
    {
      string recordTitle1 = "Thrust";
      string recordArtist = "Herbie Hancock";
      string recordTitle2 = "Save Me";
      string recordArtist2 = "Jenny Hancock";
      string recordTitle3 = "Save Me Again";
      string recordArtist3 = "Jenny Hancock";

      Record newRecord1 = new Record(recordTitle1, recordArtist);
      Record newRecord2 = new Record(recordTitle2, recordArtist2);
      Record newRecord3 = new Record(recordTitle3, recordArtist3);

      List<Record> expected = new List<Record> { newRecord2, newRecord3 };

      List<Record> result = Record.GetAllByArtist("Jenny Hancock");

      CollectionAssert.AreEqual(expected, result);
    }
  }
}