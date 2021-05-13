using System.Collections.Generic;

namespace MusicOrganizer.Models
{
  public class Record
  {
    public string Title { get; set; }
    public string Artist { get; set; }

    public int Id { get; }

    private static List<Record> _recordsList = new List<Record> { };
    private static List<string> _allArtists = new List<string> { };


    public Record(string recordTitle, string artist)
    {
      Title = recordTitle;
      Artist = artist;
      _recordsList.Add(this);
      Id = _recordsList.Count;

      if (!_allArtists.Contains(artist))
      {
        _allArtists.Add(artist);
      }
    }
    public static void ClearAll()
    {
      _recordsList.Clear();
    }

    public static List<Record> GetAll()
    {
      return _recordsList;
    }

    public static Record Find(int searchId)
    {
      return _recordsList[searchId - 1];
    }

    public static List<Record> GetAllByArtist(string artist)
    {
      List<Record> recordsByArtist = new List<Record> { };
      foreach (Record record in _recordsList)
      {
        if (record.Artist == artist)
        {
          recordsByArtist.Add(record);
        }
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
  }
}