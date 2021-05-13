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
      Record newRecord = new Record("Thrust");
      Assert.AreEqual(typeof(Record), newRecord.GetType());
    }

    [TestMethod]
    public void GetRecordTitle_ReturnRecordTitle_String()
    {
      string recordTitle = "Thrust";

      Record newRecord = new Record(recordTitle);
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
      string recordTitle2 = "Save Me";
      Record newRecord1 = new Record(recordTitle1);
      Record newRecord2 = new Record(recordTitle2);
      List<Record> newList = new List<Record> { newRecord1, newRecord2 };

      List<Record> result = Record.GetAll();

      CollectionAssert.AreEqual(newList, result);
    }
    [TestMethod]

    public void Find_ReturnsAccurateRecord_Record()
    {
      
    }
  }
}