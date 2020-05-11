using System;
using MyBeepr.Domain.Holidays.Entities;

namespace MyBeepr.Domain.Holidays
{
    public class Holiday : IHoliday
    {
        public DateTime Date { get; private set; }
        public HolidayTypes HolidayType { get; private set; }
        public bool IsDisabled { get; private set; }
        public string Name { get; private set; }

        public Holiday(
            string name,
            DateTime date, 
            HolidayTypes holidayType)
        {
            Name = name;
            Date = date;
            HolidayType = holidayType;
        }
    }
}