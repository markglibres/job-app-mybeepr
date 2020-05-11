using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyBeepr.Domain.Holidays
{
    public interface IHolidayTypeService
    {
        Task<IEnumerable<Holiday>> GetHolidays(DateTime start, DateTime end);
    }
}