using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Gas
{
   public class LegacyCalculatorTests
   {
      [Test]
      public void Empty()
      {
         // arrange
         LegacyCalculator calculator = new LegacyCalculator();

         // act
         IPlannedStart result = calculator.Calculate(new List<DateTime>());

         // assert
         Assert.AreEqual(DateTime.MinValue, result.StartTime);
         Assert.AreEqual(0, result.Count);
      }

      [Test]
      public void WithOneDate()
      {
         // arrange
         LegacyCalculator calculator = new LegacyCalculator();
         List<DateTime> dates = new List<DateTime> { new DateTime() };

         // act
         IPlannedStart result = calculator.Calculate(dates);

         // assert
         Assert.AreEqual(DateTime.MinValue, result.StartTime);
         Assert.AreEqual(0, result.Count);
      }

      [Test]
      public void WithManyDates()
      {
         // arrange
         LegacyCalculator calculator = new LegacyCalculator();
         List<DateTime> dates = new List<DateTime> {
            new DateTime(2018, 1, 1),
            new DateTime(2018, 1, 2),
            new DateTime(2018, 1, 10),
            new DateTime(2018, 1, 11),
            new DateTime(2018, 1, 12)
         };

         // act
         IPlannedStart result = calculator.Calculate(dates);

         // assert
         Assert.AreEqual(new DateTime(2018, 1, 8), result.StartTime);
         Assert.AreEqual(3, result.Count);
      }
   }
}
