using System.Collections.Generic;
using BizzPo.Core.Domain;
using Microsoft.Extensions.DependencyInjection;
using MyBeepr.Domain.Holidays;
using MyBeepr.Domain.Holidays.Entities;
using MyBeepr.Infrastructure.Repositories.Holidays;

namespace MyBeepr.Presentation.Api.Configs.HolidayTypes
{
    public static class SlidingDayHolidayConfiguration
    {
        public static void AddSlidingDayHoliday(this IServiceCollection services)
        {
            services.AddSingleton<IRepository<SlidingDayHoliday>, InMemorySlidingDayRepository>(opt =>
            {
                var initialData = new List<SlidingDayHoliday>
                {
                    new SlidingDayHoliday("Australia Day", 1, 26)
                };
                return new InMemorySlidingDayRepository(initialData);
            });

            services.AddTransient<IHolidayTypeService, SlidingDayHolidayService>();
        }
    }
}