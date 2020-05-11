using System.Collections.Generic;
using BizzPo.Core.Domain;
using Microsoft.Extensions.DependencyInjection;
using MyBeepr.Domain.Holidays;
using MyBeepr.Domain.Holidays.Entities;
using MyBeepr.Infrastructure.Repositories.Holidays;

namespace MyBeepr.Presentation.Api.Configs.HolidayTypes
{
    public static class FixedDayHolidayConfiguration
    {
        public static void AddFixedDayHolidays(this IServiceCollection services)
        {
            services.AddSingleton<IRepository<FixedDayHoliday>, InMemoryFixedDayRepository>(opt =>
            {
                var initialData = new List<FixedDayHoliday>
                {
                    new FixedDayHoliday("Anzac Day", 4, 25)
                };
                return new InMemoryFixedDayRepository(initialData);
            });
            services.AddTransient<IHolidayTypeService, FixedDayHolidayService>();
        }
    }
}