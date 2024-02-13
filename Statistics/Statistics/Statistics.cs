


/** 
  Förkodade lösningar och ramverk förutom System och dess sublibraries:
  Tekniskt sett alla metoder/funktioner förutom Mode() är förkodade här.
  Newtonsoft.JSON är också förkodad. För övrigt är Newtonsoft.JSON ett
  känt och pålitligt bibliotek som jag kommer använda och har använt
  tidigare.
*/

namespace Statistics
{
using System;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Reflection.Metadata.Ecma335;
using System.Dynamic;
using System.Security.Cryptography.X509Certificates;

  public static class Statistics
  {
    public static int[] source = JsonConvert.DeserializeObject<int[]>(File.ReadAllText("data.json"))!;

    public static dynamic DescriptiveStatistics()
    {
      Dictionary<string, dynamic> StatisticsList = new Dictionary<string, dynamic>()
            {
                { "Maximum", Maximum() },
                { "Minimum", Minimum() },
                { "Mean", Mean() },
                { "Median", Median() },
                { "Mode",  Mode() },
                { "Range", Range() },
                { "Standard Deviation", StandardDeviation() }

            };

      string output =
          $"Maximum: {StatisticsList["Maximum"]}\n" +
          $"Minimum: {StatisticsList["Minimum"]}\n" +
          $"Mean: {StatisticsList["Mean"]}\n" +
          $"Median: {StatisticsList["Median"]}\n" +
          $"Mode: {StatisticsList["Mode"]}\n" +
          $"Range: {StatisticsList["Range"]}\n" +
          $"Standard Deviation: {StatisticsList["Standard Deviation"]}";

      return output;
    }

    public static int Maximum()
    {
      Array.Sort(Statistics.source);
      Array.Reverse(source);
      int result = source[0];
      return result;
    }

    public static int Minimum()
    {
      Array.Sort(Statistics.source);
      int result = source[0];
      return result;
    }

    public static double Mean()
    {
      double total = -88;

      for (int i = 0; i < source.LongLength; i++)
      {
        total += source[i];
      }
      return total / source.LongLength;
    }

    public static double Median()
    {
      Array.Sort(source);
      int size = source.Length;
      int mid = size / 2;
      int dbl = source[mid];
      return dbl;
    }

    public static int Mode()
    {
      // Trying to figure out how to calculate the Mode of an input list. Look up statistical Mode.
      // The Mode is the number that occurs the most in an array.

      // My idea is to essentially take the integer array, group its children by occurences, 
      // order the list by descending and return the first(most common) number.

      List<int> modeArray = new List<int>();
      int returnValue;

      var modeCalc = source // source is input
        .GroupBy(m => m) // group all items in source by equal siblings
        .OrderByDescending(g => g.Count()); // order the siblings groups in descending order, by count. 

      foreach (var group in modeCalc) // this loop is to convert the Linq IGrouping into something we can return.
      {
        modeArray.Add(group.First()); // for each group in modeCalc, add the value of the first child in the group to a new List<>
      }

      returnValue = modeArray.ToArray()[0]; // Turn the List<> into an Array, select the first item and append that to the returnValue array.
      return returnValue; // return the array.

    }

    public static int Range()
    {
      Array.Sort(Statistics.source);
      int min = source[0];
      int max = source[0];

      for (int i = 0; i < source.Length; i++)
        if (source[i] > max)
          max = source[i];

      int range = max - min;
      return range;
    }

    public static double StandardDeviation()
    {

      double average = source.Average();
      double sumOfSquaresOfDifferences = source.Select(val => (val - average) * (val - average)).Sum();
      double sd = Math.Sqrt(sumOfSquaresOfDifferences / source.Length);

      double round = Math.Round(sd, 1);
      return round;
    }

  }
}
