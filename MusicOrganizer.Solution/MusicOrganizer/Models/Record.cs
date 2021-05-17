using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace MusicOrganizer.Models
{
  public class Record
  {
    public string Title { get; set; }
    public string Artist { get; set; }

    public int Id { get; set; }
    private static List<string> _allArtists = new List<string> { };

    public override bool Equals(System.Object otherRecord)
    {
      if (!(otherRecord is Record))
      {
        return false;
      }
      else
      {
        Record newRecord = (Record) otherRecord;
        bool titleEquality = (this.Title == newRecord.Title);
        bool artistEquality = (this.Artist == newRecord.Artist);
        bool idEquality = (this.Id == newRecord.Id);
        return (titleEquality && artistEquality && idEquality);
      }
    }
    public Record(string recordTitle, string artist)
    {
      Title = recordTitle;
      Artist = artist;

      if (!_allArtists.Contains(artist))
      {
        _allArtists.Add(artist);
      }
    }
    public Record(string recordTitle, string artist, int id)
    {
      Title = recordTitle;
      Artist = artist;
      Id = id;
    }
    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM records;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static List<Record> GetAll()
    {
      List<Record> allRecords = new List<Record> { };
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM records;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while (rdr.Read())
      {
        int recordId = rdr.GetInt32(0);
        string recordTitle = rdr.GetString(1);
        string recordArtist = rdr.GetString(2);
        Record newRecord = new Record(recordTitle, recordArtist, recordId);
        allRecords.Add(newRecord);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allRecords;
    }

    public static Record Find(int searchId)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM records WHERE id = @thisId;";

      MySqlParameter thisId = new MySqlParameter();
      thisId.ParameterName = "@thisId";
      thisId.Value = searchId;
      cmd.Parameters.Add(thisId);

      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int recordId = 0;
      string recordTitle = "";
      string recordArtist = "";
      while (rdr.Read())
      {
        recordId = rdr.GetInt32(0);
        recordTitle = rdr.GetString(1);
        recordArtist = rdr.GetString(2);
      }
      Record foundRecord = new Record(recordTitle, recordArtist, recordId);

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return foundRecord;
    }

    public static List<Record> GetAllByArtist(string artist)
    {
      List<Record> recordsByArtist = new List<Record> { };
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM records WHERE artist = @RecordArtist;";
      cmd.Parameters.AddWithValue("@RecordArtist", artist);
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while (rdr.Read())
      {
        int recordId = rdr.GetInt32(0);
        string recordTitle = rdr.GetString(1);
        string recordArtist = rdr.GetString(2);
        Record newRecord = new Record(recordTitle, recordArtist, recordId);
        recordsByArtist.Add(newRecord);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return recordsByArtist;
    }
    public static List<string> GetArtists()
    {
      // List<string> allArtists = new List<string> { };
      // foreach (Record record in __recordsList)
      // {
      //   string nameOfArtist = record.Artist;
      //   if (!allArtists.Contains(nameOfArtist))
      //   {
      //     allArtists.Add(nameOfArtist);
      //   }
      // }
      // return allArtists;
      return _allArtists;
    }

    public static void DeleteRecord(int recordId)
    {
      // _recordsList.RemoveAt(recordId-1);
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO records (title, artist) VALUES (@RecordTitle, @RecordArtist);";
      cmd.Parameters.AddWithValue("@RecordTitle", this.Title);
      cmd.Parameters.AddWithValue("@RecordArtist", this.Artist);
      cmd.ExecuteNonQuery();
      Id = (int)cmd.LastInsertedId;
      conn.Close();
      if(conn != null)
      {
        conn.Dispose();
      }
    }
  }
}