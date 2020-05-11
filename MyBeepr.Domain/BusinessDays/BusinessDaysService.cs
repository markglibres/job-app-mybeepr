using System;

namespace MyBeepr.Domain.BusinessDays
{
    public class BusinessDaysService : IBusinessDaysService
    {
        public int GetWorkingDays(DateTime start, DateTime end)
        {
            if (end.Date <= start.Date) return 0;

            //shift start date to start day of the week
            var startDate = start.Date.AddDays((int)start.DayOfWeek * -1);
            //shift end date to end day of the week
            var endDate = end.Date.AddHours(24).AddDays((int)DayOfWeek.Saturday - (int)end.DayOfWeek);

            //get total days with full weeks range
            var fullDaysTotal = endDate.Subtract(startDate).TotalDays;
            //get total weekends
            var weekendsTotal = (int)(fullDaysTotal / 7 * 2);
            //get total weekdays
            fullDaysTotal -= weekendsTotal;

            //get offset of start and end dates
            var startOffset = Convert.ToInt16(start.Date.DayOfWeek) - (int)DayOfWeek.Monday;
            var endOffset = (int)DayOfWeek.Friday - Convert.ToInt16(end.Date.DayOfWeek);

            if (startOffset < 0) startOffset = 0;
            if (endOffset < 0) endOffset = 0;

            //remove these blocks of code if to and from dates are to be inclusive
            if (start.Date.DayOfWeek != DayOfWeek.Sunday && start.Date.DayOfWeek != DayOfWeek.Saturday)
                startOffset += 1;
            if (end.Date.DayOfWeek != DayOfWeek.Sunday && end.Date.DayOfWeek != DayOfWeek.Saturday)
                endOffset += 1;

            //subtract offset days as a result of shifting the start and end of day
            var totalWorkdays = fullDaysTotal - (startOffset + endOffset);

            return Convert.ToInt32(totalWorkdays);
        }
    }
}