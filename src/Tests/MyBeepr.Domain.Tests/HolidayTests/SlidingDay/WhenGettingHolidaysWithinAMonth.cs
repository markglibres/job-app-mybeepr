using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using MyBeepr.Domain.Holidays;
using Xunit;

namespace MyBeepr.Domain.Tests.HolidayTests.SlidingDay
{
    public class WhenGettingHolidaysWithinAMonth : GivenSlidingDayHolidayService
    {
        private IEnumerable<Holiday> _result;

        public override async Task WhenAsync()
        {
            _result = await HolidayService.GetHolidays(
                new DateTime(2020, 5, 1),
                new DateTime(2020, 5, 31));
        }

        [Fact]
        public void Should_Not_Return_Empty_Collection()
        {
            _result.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public void Should_Return_1_Holiday()
        {
            _result.Should().HaveCount(1);
        }

        [Fact]
        public void Should_Return_Expected_Sliding_Date()
        {
            _result.First().Date.Date.Should().Be(new DateTime(2020, 5, 4));
        }
    }
}