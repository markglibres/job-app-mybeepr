using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BizzPo.Core.Domain;
using Microsoft.Extensions.Logging;
using MyBeepr.Domain.Holidays.Entities;

namespace MyBeepr.Domain.Holidays
{
    public class SlidingDayHolidayService : IHolidayTypeService
    {
        private readonly ILogger<SlidingDayHolidayService> _logger;
        private readonly IRepository<SlidingDayHoliday> _repository;

        public SlidingDayHolidayService(
            ILogger<SlidingDayHolidayService> logger,
            IRepository<SlidingDayHoliday> repository)
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
                    .Select(h =>
                    {
                        var exactDate = new DateTime(year, h.Month, h.Day);
                        var offset = 0;

                        if (exactDate.DayOfWeek == DayOfWeek.Saturday)
                        {
                            offset = 2;
                        }
                        else if (exactDate.DayOfWeek == DayOfWeek.Sunday)
                        {
                            offset = 1;
                        }

                        var date = exactDate.AddDays(offset);

                        return new Holiday(h.Name, date, HolidayTypes.SlidingDay);
                    });

                holidaysWithExactDate.AddRange(dates
                    .Where(h => start.Date.Date < h.Date.Date && h.Date.Date < end.Date.Date));
            }

            return holidaysWithExactDate;
        }
    }
}