using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace MyBeepr.Domain.Holidays
{
    public interface IHolidayService
    {
        Task<IEnumerable<Holiday>> GetHolidays(DateTime start, DateTime end);
    }
}