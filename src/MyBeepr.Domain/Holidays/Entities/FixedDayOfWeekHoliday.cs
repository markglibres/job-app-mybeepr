using System;
using Ardalis.GuardClauses;
using BizzPo.Core.Domain;
using MyBeepr.Domain.Extensions;
using Newtonsoft.Json;

namespace MyBeepr.Domain.Holidays.Entities
{
    public class FixedDayOfWeekHoliday : Entity, IHoliday
    {
        public int Month { get; private set; }
        public DayOfWeek DayOfWeek { get; private set; }
        public int DayOrder { get; private set; }
        public HolidayTypes HolidayType { get; private set; }
        public bool IsDisabled { get; private set; }
        public string Name { get; private set; }

        [JsonConstructor]
        private FixedDayOfWeekHoliday()
        {
        }

        public FixedDayOfWeekHoliday(
            string name,
            int month,
            DayOfWeek dayOfWeek,
            int dayOrder)
        {
            Guard.Against.InvalidFixedDayOfWeekHoliday<DomainException>(month, dayOfWeek, dayOrder);

            Name = name;
            Month = month;
            DayOfWeek = dayOfWeek;
            DayOrder = dayOrder;
            HolidayType = HolidayTypes.FixedDayOfWeek;
        }
    }
}
