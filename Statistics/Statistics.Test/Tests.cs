/**
Expected: 
Max: 378
Min: -42
Mean: 167,32713457308537
Median: 165
Mode: 31
Range: 420
Standard Deviation: 122,3
*/
using Statistics;
using Xunit;

namespace Statistics
{
  public class Tests
  {
    [Fact]
    public void MaximumTest()
    {
      int expected = 378;
      if (Statistics.Maximum() != expected)
      {
      Assert.Fail("Expected value not reached");
      }
      Assert.True(true, "Expected value reached");
    }
    [Fact]
    public void MinimumTest()
    {
      int expected = -42;
      if (Statistics.Minimum() != expected)
      {
      Assert.Fail("Expected value not reached");
      }
      Assert.True(true, "Expected value reached");
    }
    [Fact]
    public void MeanTest()
    {
      double expected = 167.32713457308537;
      if (Statistics.Mean() != expected)
      {
      Assert.Fail("Expected value not reached");
      }
      Assert.True(true, "Expected value reached");
    }
    [Fact]
    public void MedianTest()
    {
      double expected = 165;
      if (Statistics.Median() != expected)
      {
      Assert.Fail("Expected value not reached");
      }
      Assert.True(true, "Expected value reached");
    }
    [Fact]
    public void ModeTest()
    {
      int expected = 31;
      if (Statistics.Mode() != expected)
      {
      Assert.Fail("Expected value not reached");
      }
      Assert.True(true, "Expected value reached");
    }
    [Fact]
    public void RangeTest()
    {
      int expected = 420;
      if (Statistics.Range() != expected)
      {
      Assert.Fail("Expected value not reached");
      }
      Assert.True(true, "Expected value reached");
    }
    [Fact]
    public void StandardDeviationTest()
    {
      double expected = 122.3;
      if (Statistics.StandardDeviation() != expected)
      {
      Assert.Fail($"Expected value not reached.");
      }
      Assert.True(true, "Expected value reached");
    }
  }
}