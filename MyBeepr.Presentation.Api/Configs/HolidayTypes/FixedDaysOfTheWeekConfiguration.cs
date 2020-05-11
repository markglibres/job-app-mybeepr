using System;
using System.Collections.Generic;
using BizzPo.Core.Domain;
using Microsoft.Extensions.DependencyInjection;
using MyBeepr.Domain.Holidays;
using MyBeepr.Domain.Holidays.Entities;
using MyBeepr.Infrastructure.Repositories.Holidays;

namespace MyBeepr.Presentation.Api.Configs.HolidayTypes
{
    public static class FixedDaysOfTheWeekConfiguration
    {
        public static void AddFixedDayOfWeekHoliday(this IServiceCollection services)
        {
            services.AddSingleton<IRepository<FixedDayOfWeekHoliday>, InMemoryFixedDayOfWeekRepository>(opt =>
            {
                var initialData = new List<FixedDayOfWeekHoliday>
                {
                    new FixedDayOfWeekHoliday("Queen's Birthday'", 6, DayOfWeek.Monday, 2)
                };
                return new InMemoryFixedDayOfWeekRepository(initialData);
            });

            services.AddTransient<IHolidayTypeService, FixedDayOfWeekHolidayService>();
        }
    }
}