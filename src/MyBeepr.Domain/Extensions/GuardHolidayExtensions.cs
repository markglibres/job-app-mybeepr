using System;
using System.Globalization;
using System.Reflection;
using Ardalis.GuardClauses;

namespace MyBeepr.Domain.Extensions
{
    public static class GuardHolidayExtensions
    {
        public static void InvalidMonthDayHoliday<T>(
            this IGuardClause guardClause,
            int month,
            int day)
            where T : Exception
        {
            if (DateTime.TryParse($"{DateTime.Now.Year}-{month}-{day}", out _)) return;

            ThrowError<T>($"Invalid month day value");

        }

        public static void InvalidFixedDayOfWeekHoliday<T>(
            this IGuardClause guardClause,
            int month,
            DayOfWeek dayOfWeek,
            int dayOrder)
            where T : Exception
        {
            if(month < 1 || month > 12)
            {
                ThrowError<T>($"Month value out of range. Value must be between 1-12");
            }

            if (dayOrder < 1 || dayOrder > 5)
            {
                ThrowError<T>($"Day order out of range. Value must be between 1-6");
            }

        }

        private static void ThrowError<T>(string message)
            where T : Exception
        {
            throw (T) Activator.CreateInstance(typeof(T),
                BindingFlags.CreateInstance |
                BindingFlags.Public |
                BindingFlags.Instance |
                BindingFlags.OptionalParamBinding,
                null,
                new[]
                {
                    message, Type.Missing, Type.Missing, Type.Missing
                },
                CultureInfo.CurrentCulture);
        }
    }
}