using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace MyBeepr.Domain.Holidays
{
    public class HolidayService : IHolidayService
    {
        private readonly List<IHolidayTypeService> _holidayTypeServices;
        private readonly ILogger<HolidayService> _logger;

        public HolidayService(
            ILogger<HolidayService> logger,
            IEnumerable<IHolidayTypeService> holidayTypeServices)
        {
            _logger = logger;
            _holidayTypeServices = holidayTypeServices.ToList();
        }

        public async Task<IEnumerable<Holiday>> GetHolidays(DateTime start, DateTime end)
        {
            _logger.LogInformation($"Getting holidays from {start:D} to {end:D}");
            var tasks = new List<Task<IEnumerable<Holiday>>>();
            _holidayTypeServices
                .ForEach(holidayService =>
                {
                    _logger.LogInformation($"Getting holidays with {holidayService.GetType().Name}");
                    tasks.Add(holidayService.GetHolidays(start, end));
                });

            var result = await Task.WhenAll(tasks);

            var holidays = result
                .SelectMany(item => item)
                .ToList();

            _logger.LogInformation($"Found {holidays.Count()} from {start:D} to {end:D}");
            return holidays;
        }
    }
}