using Microsoft.Extensions.DependencyInjection;
using MyBeepr.Domain.BusinessDays;
using MyBeepr.Domain.Holidays;
using MyBeepr.Presentation.Api.Configs.HolidayTypes;

namespace MyBeepr.Presentation.Api.Configs
{
    public static class BusinessDaysConfiguration
    {
        public static void AddBusinessDays(this IServiceCollection services)
        {
            services.AddTransient<IHolidayService, HolidayService>();
            services.AddTransient<IBusinessDaysService, BusinessDaysService>();

            services.AddFixedDayHolidays();
            services.AddFixedDayOfWeekHoliday();
            services.AddSlidingDayHoliday();
        }
    }
}