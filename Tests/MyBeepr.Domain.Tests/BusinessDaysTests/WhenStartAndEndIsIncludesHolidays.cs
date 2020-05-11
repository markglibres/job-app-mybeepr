using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using MyBeepr.Domain.Holidays;
using MyBeepr.Domain.Holidays.Entities;
using Xunit;

namespace MyBeepr.Domain.Tests.BusinessDaysTests
{
    public class WhenStartAndEndIsIncludesHolidays : GivenBusinessDaysService
    {
        private int _result;

        public override void Given()
        {
            base.Given();
            MockHolidayService.Setup(s => s.GetHolidays(
                    It.IsAny<DateTime>(),
                    It.IsAny<DateTime>()))
                .ReturnsAsync(new List<Holiday>
                {
                    new Holiday("Holiday 1", new DateTime(2020, 5, 13), HolidayTypes.FixedDay)
                });
        }

        public override async Task WhenAsync()
        {
            var startDate = new DateTime(2020, 5, 1);
            var endDate = new DateTime(2020, 5, 31);
            _result = await BusinessDaysService.GetWorkingDays(startDate, endDate);
        }

        [Fact]
        public void Should_Return_19_Working_Days()
        {
            _result.Should().Be(19);
        }
    }
}