using System.Threading.Tasks;
using AutoFixture;
using BizzPo.Core.Domain;
using BizzPo.Core.Infrastructure.Repository.InMemory;
using MyBeepr.Domain.Holidays;
using MyBeepr.Domain.Holidays.Entities;
using MyBeepr.Tests;

namespace MyBeepr.Domain.Tests.HolidayTests.FixedDay
{
    public abstract class GivenFixedDayHolidayService : TestSpecification
    {
        protected FixedDayHolidayService HolidayService;

        public override async Task GivenAsync()
        {
            var repo = Fixture.Create<InMemoryRepository<FixedDayHoliday>>();
            await repo.InsertAsync(new FixedDayHoliday("May 24 Holiday", 4, 24));
            await repo.InsertAsync(new FixedDayHoliday("Sep 8 Holiday", 9, 8));

            Fixture.Customize<IRepository<FixedDayHoliday>>(o => o
                .FromFactory(() => repo));

            HolidayService = Fixture.Create<FixedDayHolidayService>();
        }
    }
}