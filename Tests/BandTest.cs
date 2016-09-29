using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BandTracker
{
  public class BandTest : IDisposable
  {
    public BandTest()
    {
        DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=band_tracker_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void Test1_DatabaseEmptyAtFirst()
    {
      int result = Band.GetAll().Count;

      Assert.Equal(0, result);
    }

    [Fact]
   public void Test2_ReturnsForSameName()
   {
     Band firstBand = new Band("Greenday");
     Band secondBand = new Band("Greenday");

     Assert.Equal(firstBand, secondBand);
   }


    [Fact]
    public void Test3_SavesToDatabase()
    {
      Band testBand = new Band("Nirvana");

      testBand.Save();
      List<Band> result = Band.GetAll();
      List<Band> testList = new List<Band>{testBand};

      Assert.Equal(testList, result);
    }

    [Fact]
   public void Test4_SavesIdForBandObject()
   {
     Band testBand = new Band("Nirvana");
     testBand.Save();

     Band savedBand = Band.GetAll()[0];

     int result = savedBand.GetId();
     int testId = testBand.GetId();

     Assert.Equal(testId, result);
   }

   [Fact]
   public void Test5_FindBandInDatabase()
   {
     Band testBand = new Band("Sting");
     testBand.Save();

     Band foundBand = Band.Find(testBand.GetId());

     Assert.Equal(testBand, foundBand);
   }

   [Fact]
    public void Test6_AddsVenueToBand()
    {
      Band testBand = new Band("Nirvana");
      testBand.Save();

      Venue testVenue = new Venue("Acc");
      testVenue.Save();
      testBand.AddVenue(testVenue);

      List<Venue> result = testBand.GetVenues();
      List<Venue> testList = new List<Venue>{testVenue};

      Assert.Equal(testList, result);
    }

    [Fact]
    public void Test7_MatchVenuesWithBandVenues()
    {
      Band testBand = new Band("Nirvana");
      testBand.Save();

      Venue testVenue1 = new Venue("Acc");
      testVenue1.Save();

      Venue testVenue2 = new Venue("Skydome");
      testVenue2.Save();

      testBand.AddVenue(testVenue1);
      List<Venue> result = testBand.GetVenues();
      List<Venue> testList = new List<Venue> {testVenue1};

      Assert.Equal(testList, result);
    }

    [Fact]
   public void Test8_DeleteOneFromDatabase()
   {
     Venue testVenue = new Venue("Skydome");
     testVenue.Save();

     Band testBand = new Band("Ac/dc");
     testBand.Save();

     testBand.AddVenue(testVenue);
     testBand.Delete();

     List<Band> resultVenueBands = testVenue.GetBands();
     List<Band> testVenueBands = new List<Band> {};

     Assert.Equal(testVenueBands, resultVenueBands);
   }

   public void Dispose()
   {
     Band.DeleteAll();
     Venue.DeleteAll();
   }

  }
}
