using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using MyBeepr.Domain.Holidays;
using MyBeepr.Domain.Holidays.Entities;
using MyBeepr.Tests;
using Xunit;

namespace MyBeepr.Domain.Tests.HolidayTests
{
    public class WhenGettingHolidays : TestSpecification
    {
        private HolidayService _holidayService;
        private IEnumerable<IHoliday> _result;

        public override void Given()
        {
            var fixedDay = Fixture.Create<Mock<IHolidayTypeService>>();
            var fixedDayOfWeek = Fixture.Create<Mock<IHolidayTypeService>>();
            var slidingDay = Fixture.Create<Mock<IHolidayTypeService>>();

            fixedDay.Setup(s => s.GetHolidays(It.IsAny<DateTime>(), It.IsAny<DateTime>()))
                .ReturnsAsync(new List<Holiday> {new Holiday("Holiday 1", DateTime.Now, HolidayTypes.FixedDay)});
            fixedDayOfWeek.Setup(s => s.GetHolidays(It.IsAny<DateTime>(), It.IsAny<DateTime>()))
                .ReturnsAsync(new List<Holiday> {new Holiday("Holiday 2", DateTime.Now, HolidayTypes.FixedDayOfWeek) });
            slidingDay.Setup(s => s.GetHolidays(It.IsAny<DateTime>(), It.IsAny<DateTime>()))
                .ReturnsAsync(new List<Holiday> {new Holiday("Holiday 3", DateTime.Now, HolidayTypes.SlidingDay) });

            Fixture.Customize<IEnumerable<IHolidayTypeService>>(o => o
                .FromFactory(() => new List<IHolidayTypeService>
                {
                    fixedDay.Object,
                    fixedDayOfWeek.Object,
                    slidingDay.Object
                }));

            _holidayService = Fixture.Create<HolidayService>();
        }

        public override async Task WhenAsync()
        {
            _result = await _holidayService.GetHolidays(DateTime.Now, DateTime.Now.AddDays(7));
        }

        [Fact]
        public void Should_Not_Return_Empty_Collection()
        {
            _result.Should().NotBeEmpty();
        }

        [Fact]
        public void Should_Return_3_Holiday_Items()
        {
            _result.Should().HaveCount(3);
        }
    }
}