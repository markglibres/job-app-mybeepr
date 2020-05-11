using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BizzPo.Core.Domain;
using Microsoft.Extensions.Logging;
using MyBeepr.Domain.Holidays.Entities;

namespace MyBeepr.Domain.Holidays
{
    public class FixedDayHolidayService : IHolidayTypeService
    {
        private readonly ILogger<FixedDayHolidayService> _logger;
        private readonly IRepository<FixedDayHoliday> _repository;

        public FixedDayHolidayService(
            ILogger<FixedDayHolidayService> logger,
            IRepository<FixedDayHoliday> repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<IEnumerable<Holiday>> GetHolidays(DateTime start, DateTime end)
        {
            var holidays = (await _repository.GetByAsync(q => q.Where(h => !h.IsDisabled)))
                .ToList();

            var years = new List<int> {start.Year};
            var yearDiff = end.Year - start.Year;

            if (yearDiff >= 1)
                for (var i = 1; i <= yearDiff; i++)
                    years.Add(start.Year + i);

            var holidaysWithExactDate = new List<Holiday>();

            foreach (var year in years)
            {
                var dates = holidays
                    .Select(h => new Holiday(
                        h.Name, 
                        new DateTime(year, h.Month, h.Day), 
                        HolidayTypes.FixedDay))
                    .Where(h => h.Date.DayOfWeek > DayOfWeek.Sunday && h.Date.DayOfWeek < DayOfWeek.Saturday);

                holidaysWithExactDate.AddRange(dates
                    .Where(h => start.Date.Date < h.Date.Date && h.Date.Date < end.Date.Date));
            }

            return holidaysWithExactDate;
        }
    }
}