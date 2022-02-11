using System;

namespace Gas
{
   public interface IPlannedStart
   {
      DateTime StartTime { get; set; }
      int Count { get; set; }
   }
}
