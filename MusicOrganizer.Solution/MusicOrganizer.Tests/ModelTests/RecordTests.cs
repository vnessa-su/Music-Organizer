using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicOrganizer.Models;
using System.Collections.Generic;
using System;
using MySql.Data.MySqlClient;

namespace MusicOrganizer.Tests
{
  [TestClass]
  public class RecordTests : IDisposable
  {
    public void Dispose()
    {
      Record.ClearAll();
    }

    public RecordTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=epicodus;port=3306;database=music_organizer;";
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
    public void GetAll_ReturnsEmptyListFromDatabase_RecordList()
    {
      List<Record> newList = new List<Record> { };

      List<Record> result = Record.GetAll();

      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetAll_ReturnsRecords_RecordList()
    {
      string recordTitle1 = "Thrust";
      string recordArtist = "Herbie Hancock";
      string recordTitle2 = "Save Me";
      string recordArtist2 = "Jenny Hancock";

      Record newRecord1 = new Record(recordTitle1, recordArtist);
      newRecord1.Save();
      Record newRecord2 = new Record(recordTitle2, recordArtist2);
      newRecord2.Save();
      List<Record> newList = new List<Record> { newRecord1, newRecord2 };

      List<Record> result = Record.GetAll();

      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Find_ReturnsAccurateRecordFromDatabase_Record()
    {
      string recordTitle1 = "Thrust";
      string recordArtist = "Herbie Hancock";
      string recordTitle2 = "Save Me";
      string recordArtist2 = "Jenny Hancock";

      Record newRecord1 = new Record(recordTitle1, recordArtist);
      newRecord1.Save();
      Record newRecord2 = new Record(recordTitle2, recordArtist2);
      newRecord2.Save();

      Record result = Record.Find(newRecord2.Id);

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
      newRecord1.Save();
      Record newRecord2 = new Record(recordTitle2, recordArtist2);
      newRecord2.Save();
      Record newRecord3 = new Record(recordTitle3, recordArtist3);
      newRecord3.Save();

      List<Record> expected = new List<Record> { newRecord2, newRecord3 };

      List<Record> result = Record.GetAllByArtist("Jenny Hancock");

      CollectionAssert.AreEqual(expected, result);
    }
    [TestMethod]
    public void Equals_ReturnsTrueIfTitleAndArtistAreTheSame_Record()
    {
      Record firstRecord = new Record("Fire Fire", "FlyLeaf");
      Record secondRecord = new Record("Fire Fire", "FlyLeaf");
      Assert.AreEqual(firstRecord, secondRecord);
    }

    [TestMethod]
    public void Save_SavesToDatabase_ItemList()
    {
      Record testRecord = new Record("Fire Fire", "FlyLeaf");

      testRecord.Save();
      List<Record> result = Record.GetAll();
      List<Record> testList = new List<Record>{testRecord};

      CollectionAssert.AreEqual(testList, result);
    }
  }
}