using System;
using MyBeepr.Domain.Holidays.Entities;

namespace MyBeepr.Domain.Holidays
{
    public class Holiday : IHoliday
    {
        public DateTime Date { get; private set; }
        public HolidayTypes HolidayType { get; private set; }
        public bool IsDisabled { get; private set; }

        public Holiday(DateTime date, HolidayTypes holidayType)
        {
            Date = date;
            HolidayType = holidayType;
        }
    }
}