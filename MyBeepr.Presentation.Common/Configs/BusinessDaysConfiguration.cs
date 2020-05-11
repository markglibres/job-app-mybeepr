using System;
using System.Collections.Generic;
using BizzPo.Core.Domain;
using Microsoft.Extensions.DependencyInjection;
using MyBeepr.Domain.BusinessDays;
using MyBeepr.Domain.Holidays;
using MyBeepr.Domain.Holidays.Entities;
using MyBeepr.Infrastructure.Repositories;

namespace MyBeepr.Presentation.Common.Configs
{
    public static class BusinessDaysConfiguration
    {
        public static void AddBusinessDays(this IServiceCollection services)
        {
            services.AddSingleton<IRepository<FixedDayHoliday>, InMemoryFixedDayRepository>(opt =>
            {
                var initialData = new List<FixedDayHoliday>
                {
                    new FixedDayHoliday("Anzac Day", 4, 25)
                };
                return new InMemoryFixedDayRepository(initialData);
            });
            services.AddSingleton<IRepository<FixedDayOfWeekHoliday>, InMemoryFixedDayOfWeekRepository>(opt =>
            {
                var initialData = new List<FixedDayOfWeekHoliday>
                {
                    new FixedDayOfWeekHoliday("Queen's Birthday'", 6, DayOfWeek.Monday, 2)
                };
                return new InMemoryFixedDayOfWeekRepository(initialData);
            });

            services.AddSingleton<IRepository<SlidingDayHoliday>, InMemorySlidingDayRepository>(opt =>
            {
                var initialData = new List<SlidingDayHoliday>
                {
                    new SlidingDayHoliday("Australia Day", 1, 26)
                };
                return new InMemorySlidingDayRepository(initialData);
            });

            services.AddTransient<IHolidayService, HolidayService>();
            services.AddTransient<IHolidayTypeService, FixedDayHolidayService>();
            services.AddTransient<IHolidayTypeService, FixedDayOfWeekHolidayService>();
            services.AddTransient<IHolidayTypeService, SlidingDayHolidayService>();
            services.AddTransient<IBusinessDaysService, BusinessDaysService>();
        }
    }
}