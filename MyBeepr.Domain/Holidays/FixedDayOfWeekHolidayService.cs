using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BizzPo.Core.Domain;
using Microsoft.Extensions.Logging;
using MyBeepr.Domain.Holidays.Entities;

namespace MyBeepr.Domain.Holidays
{
    public class FixedDayOfWeekHolidayService : IHolidayTypeService
    {
        private readonly ILogger<FixedDayOfWeekHolidayService> _logger;
        private readonly IRepository<FixedDayOfWeekHoliday> _repository;

        public FixedDayOfWeekHolidayService(
            ILogger<FixedDayOfWeekHolidayService> logger,
            IRepository<FixedDayOfWeekHoliday> repository)
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
                var dates = holidays.Select(h =>
                {
                    var firstDayOfTheMonth = new DateTime(year, h.Month, 1);
                    var offset = 0;
                    if ((int) firstDayOfTheMonth.DayOfWeek > (int) h.DayOfWeek)
                    {
                        offset = (int) DayOfWeek.Saturday - (int) firstDayOfTheMonth.DayOfWeek;
                        offset += (int) h.DayOfWeek + 1;
                    }
                    else
                    {
                        offset = (int) h.DayOfWeek - (int) firstDayOfTheMonth.DayOfWeek;
                    }

                    offset += (h.DayOrder - 1) * 7;

                    return firstDayOfTheMonth.AddDays(offset);
                });
                holidaysWithExactDate.AddRange(dates.Where(h => start.Date < h.Date && h.Date < end.Date));
            }

            var validHolidays = holidaysWithExactDate
                .Select(h => new Holiday(h, HolidayTypes.FixedDayOfWeek));

            return validHolidays;
        }
    }
}