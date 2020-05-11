using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using MyBeepr.Domain.Holidays;
using Xunit;

namespace MyBeepr.Domain.Tests.HolidayTests.SlidingDay
{
    public class WhenGettingHolidaysWithinWeekday : GivenSlidingDayHolidayService
    {
        private IEnumerable<Holiday> _result;

        public override async Task WhenAsync()
        {
            _result = await HolidayService.GetHolidays(
                new DateTime(2021, 9, 1),
                new DateTime(2021, 9, 28));
        }

        [Fact]
        public void Should_Not_Return_Empty_Collection()
        {
            _result.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public void Should_Return_1_Holidays()
        {
            _result.Should().HaveCount(1);
        }

        [Fact]
        public void Should_Return_Expected_Same_Date()
        {
            _result.First().Date.Date.Should().Be(new DateTime(2021, 9, 6));
        }
    }
}