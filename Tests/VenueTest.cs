using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BandTracker
{
  public class VenueTest : IDisposable
  {
    public VenueTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=band_tracker_test;Integrated Security=SSPI;";
    }

    public void Dispose()
    {
      Venue.DeleteAll();
    }

    [Fact]
    public void Test1_TestsEmptyAtFirst()
    {
      int result = Venue.GetAll().Count;

      Assert.Equal(0, result);
    }

    [Fact]
   public void Test2_ReturnsForSameName()
   {
     Venue firstVenue = new Venue("Skydome");
     Venue secondVenue = new Venue("Skydome");

     Assert.Equal(firstVenue, secondVenue);
   }

    [Fact]
    public void Test3_SavesToDatabase()
    {
      Venue testVenue = new Venue("Skydome");
      testVenue.Save();

      List<Venue> result = Venue.GetAll();
      List<Venue> testList = new List<Venue>{testVenue};

      Assert.Equal(testList, result);
    }

    [Fact]
   public void Test4_Save_AssignsId()
   {
     Venue testVenue = new Venue("Skydome");
     testVenue.Save();

     Venue savedVenue = Venue.GetAll()[0];

     int result = savedVenue.GetId();
     int testId = testVenue.GetId();

     Assert.Equal(testId, result);
   }

   [Fact]
   public void Test5_FindsVenueInDatabase()
   {
     Venue testVenue = new Venue("Skydome");
     testVenue.Save();

     Venue foundVenue = Venue.Find(testVenue.GetId());

     Assert.Equal(testVenue, foundVenue);
   }

   [Fact]
   public void Test6_DeletesFromDatabase()
   {
     string name1 = "Skydome";
     Venue testVenue1 = new Venue(name1);
     testVenue1.Save();

     string name2 = "Acc";
     Venue testVenue2 = new Venue(name2);
     testVenue2.Save();

     testVenue1.Delete();
     List<Venue> resultVenues = Venue.GetAll();
     List<Venue> testVenueList = new List<Venue> {testVenue2};

     Assert.Equal(testVenueList, resultVenues);
   }


    [Fact]
  public void Test7_AddsBandToVenue()
  {
    //Arrange
    Venue testVenue = new Venue("skydome");
    testVenue.Save();

    Band testBand1 = new Band("The Doors");
    testBand1.Save();

    Band testBand2 = new Band("Nirvana");
    testBand2.Save();

    testVenue.AddBand(testBand1);
    testVenue.AddBand(testBand2);

    List<Band> result = testVenue.GetBands();
    List<Band> testList = new List<Band>{testBand1, testBand2};

    Assert.Equal(testList, result);
  }

  }
}
