using System;
using System.Threading.Tasks;
using AutoFixture;
using BizzPo.Core.Domain;
using BizzPo.Core.Infrastructure.Repository.InMemory;
using MyBeepr.Domain.Holidays;
using MyBeepr.Domain.Holidays.Entities;
using MyBeepr.Tests;

namespace MyBeepr.Domain.Tests.HolidayTests.FixedDayOfTheWeek
{
    public abstract class GivenFixedDayOfTheWeekHolidayService : TestSpecification
    {
        protected FixedDayOfWeekHolidayService HolidayService;

        public override async Task GivenAsync()
        {
            var repo = Fixture.Create<InMemoryRepository<FixedDayOfWeekHoliday>>();
            await repo.InsertAsync(new FixedDayOfWeekHoliday(5, DayOfWeek.Wednesday, 2));
            await repo.InsertAsync(new FixedDayOfWeekHoliday(6, DayOfWeek.Monday, 2));

            Fixture.Customize<IRepository<FixedDayOfWeekHoliday>>(o => o
                .FromFactory(() => repo));

            HolidayService = Fixture.Create<FixedDayOfWeekHolidayService>();
        }
    }
}