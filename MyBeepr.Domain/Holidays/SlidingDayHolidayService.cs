using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MyBeepr.Domain.Holidays.Entities;

namespace MyBeepr.Domain.Holidays
{
    public class SlidingDayHolidayService : IHolidayTypeService
    {
        public SlidingDayHolidayService()
        {
            
        }
        public Task<IEnumerable<Holiday>> GetHolidays(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }
    }
}
