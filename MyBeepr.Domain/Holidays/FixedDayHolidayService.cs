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

            var holidaysWithExactDate = new List<DateTime>();
            foreach (var year in years)
            {
                var dates = holidays
                    .Select(h => new DateTime(year, h.Month, h.Day))
                    .Where(h => h.DayOfWeek > DayOfWeek.Sunday && h.DayOfWeek < DayOfWeek.Saturday);

                holidaysWithExactDate.AddRange(dates.Where(h => start.Date < h.Date && h.Date < end.Date));
            }

            var validHolidays = holidaysWithExactDate
                .Select(h => new Holiday(h, HolidayTypes.FixedDay));

            return validHolidays;
        }
    }
}