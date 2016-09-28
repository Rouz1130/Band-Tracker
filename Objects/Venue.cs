using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace BandTracker
{
  public class Venue
  {
    private int _id;
    private string _name;

    public Venue(string Name, int Id = 0)
    {
      _id = Id;
      _name = Name;
    }

    public int GetId()
    {
      return _id;
    }
    public string GetName()
    {
      return _name;
    }
    public void SetName(string newName)
    {
      _name = newName;
    }

    public static List<Venue> GetAll()
    {
      List<Venue> allVenues = new List<Venue>{};

      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM venues;", conn);
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int venueId = rdr.GetInt32(0);
        string venueName = rdr.GetString(1);
        Venue newVenue = new Venue(venueName, venueId);
        allVenues.Add(newVenue);
      }

      if (rdr != null)
      {
        conn.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return allVenues;
}

public static void DeleteAll()
{
  SqlConnection conn = DB.Connection();
  conn.Open();
  SqlCommand cmd = new SqlCommand("DELETE FROM venues;", conn);
  cmd.ExecuteNonQuery();
  conn.Close();
}

public override bool Equals(System.Object otherVenue)
{

  if (! (otherVenue is Venue))
  {
    return false;
  }
  else
  {
    Venue newVenue = (Venue) otherVenue;
    bool idEquality = this.GetId() == newVenue.GetId();
    bool nameEqaulity = this.GetName() == newVenue.GetName();
    return (idEquality && nameEqaulity);
  }
}

  // public static List<Venue> GetAll()
  // {
  //   List<Venue> allVenues = new List<Venue>{};
  //
  //   SqlConnection conn = DB.Connection();
  //   conn.Open();
  //
  //   SqlCommand cmd = new SqlCommand("SELECT * FROM venues;", conn);
  //   SqlDataReader rdr = cmd.ExecuteReader();
  //
  //   while(rdr.Read())
  //   {
  //     int venueId = rdr.GetInt32(0);
  //     string venueName = rdr.GetString(1);
  //     Venue newVenue = new Venue(venueName, venueId);
  //     allVenues.Add(newVenue);
  //   }
  //   if (rdr !=null)
  //   {
  //     rdr.Close();
  //   }
  //   if (conn != null)
  //   {
  //     conn.Close();
  //   }
  //   return allVenues;
  // }

 }
}
