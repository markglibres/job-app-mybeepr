using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using MyBeepr.Domain.Holidays;
using Xunit;

namespace MyBeepr.Domain.Tests.HolidayTests.SlidingDay
{
    public class WhenGettingHolidaysWithin2Years : GivenSlidingDayHolidayService
    {
        private IEnumerable<Holiday> _result;

        public override async Task WhenAsync()
        {
            _result = await HolidayService.GetHolidays(
                new DateTime(2020, 1, 1),
                new DateTime(2021, 12, 31));
        }

        [Fact]
        public void Should_Not_Return_Empty_Collection()
        {
            _result.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public void Should_Return_4_Holidays()
        {
            _result.Should().HaveCount(4);
        }

        [Fact]
        public void Should_Return_Expected_Sliding_Date()
        {
            _result.Any(r => r.Date.Date.Equals(new DateTime(2020, 5, 4)))
                .Should().BeTrue();
            _result.Any(r => r.Date.Date.Equals(new DateTime(2020, 9, 7)))
                .Should().BeTrue();

            _result.Any(r => r.Date.Date.Equals(new DateTime(2021, 5, 3)))
                .Should().BeTrue();
            _result.Any(r => r.Date.Date.Equals(new DateTime(2021, 9, 6)))
                .Should().BeTrue();
        }
    }
}