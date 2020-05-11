using Ardalis.GuardClauses;
using BizzPo.Core.Domain;
using MyBeepr.Domain.Extensions;
using Newtonsoft.Json;

namespace MyBeepr.Domain.Holidays.Entities
{
    public class SlidingDayHoliday : Entity, IHoliday
    {
        public int Day { get; private set; }
        public int Month { get; private set; }
        public HolidayTypes HolidayType { get; private set; }
        public bool IsDisabled { get; private set; }

        [JsonConstructor]
        private SlidingDayHoliday()
        {
        }

        public SlidingDayHoliday(
            int month,
            int day)
        {
            Guard.Against.InvalidMonthDayHoliday<DomainException>(month, day);

            Month = month;
            HolidayType = HolidayTypes.SlidingDay;
            Day = day;
            
        }

       
    }
}