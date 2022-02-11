using System;
using System.Collections.Generic;
using System.Linq;

namespace Gas
{
   public partial class LegacyCalculator
   {
      public IPlannedStart Calculate(List<DateTime> dates, int requiredDays = 1)
      {
         dates.Sort((a, b) => a.CompareTo(b));

         IPlannedStart plannedStart = new PlannedStart { StartTime = DateTime.MinValue, Count = 0 };

         // check if dates no items then return early
         if (dates.Count == 0)
         {
            return plannedStart;
         }

         DateTime startOfFirstWeek = dates[0];
         // add a week
         DateTime startOfSecondWeek = startOfFirstWeek.AddDays(7);

         int countsForFirstWeek = DateCount(dates, startOfFirstWeek, startOfSecondWeek);

         int countsForSecondWeek = DateCount(dates, startOfSecondWeek, startOfSecondWeek.AddDays(7)); // add a week

         if (countsForSecondWeek > countsForFirstWeek && countsForSecondWeek >= requiredDays)
         {
            plannedStart = new PlannedStart { StartTime = startOfSecondWeek, Count = countsForSecondWeek };
         }
         return plannedStart;
      }

      private int DateCount(List<DateTime> dates, DateTime startDate, DateTime endDate)
      {
         return dates.Where(x => x > startDate && x < endDate).Count();
      }
   }
}
