using System.Threading.Tasks;
using AutoFixture;
using BizzPo.Core.Domain;
using BizzPo.Core.Infrastructure.Repository.InMemory;
using MyBeepr.Domain.Holidays;
using MyBeepr.Domain.Holidays.Entities;
using MyBeepr.Tests;

namespace MyBeepr.Domain.Tests.HolidayTests.SlidingDay
{
    public abstract class GivenSlidingDayHolidayService : TestSpecification
    {
        protected SlidingDayHolidayService HolidayService { get; private set; }

        public override async Task GivenAsync()
        {
            var repo = Fixture.Create<InMemoryRepository<SlidingDayHoliday>>();
            await repo.InsertAsync(new SlidingDayHoliday("May 2 Holiday", 5, 2));
            await repo.InsertAsync(new SlidingDayHoliday("Sep 6 Holiday", 9, 6));

            Fixture.Customize<IRepository<SlidingDayHoliday>>(o => o
                .FromFactory(() => repo));

            HolidayService = Fixture.Create<SlidingDayHolidayService>();
        }
    }
}