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
      Band firstBand = new Band("GreenDay");
      Band secondBand = new Band("GreenDay");

      Assert.Equal(firstBand, secondBand);
    }


    public void Dispose()
    {
      Band.DeleteAll();
    }
  }
}
