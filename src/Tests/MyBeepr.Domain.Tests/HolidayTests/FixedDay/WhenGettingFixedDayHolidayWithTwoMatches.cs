using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using MyBeepr.Domain.Holidays;
using Xunit;

namespace MyBeepr.Domain.Tests.HolidayTests.FixedDay
{
    public class WhenGettingFixedDayHolidayWithTwoMatches : GivenFixedDayHolidayService
    {
        private IEnumerable<Holiday> _result;

        public override async Task WhenAsync()
        {
            _result = await HolidayService.GetHolidays(
                new DateTime(2020, 4, 1),
                new DateTime(2020, 9, 10));
        }

        [Fact]
        public void Should_Not_Return_Empty_Collection()
        {
            _result.Should().NotBeEmpty();
        }

        [Fact]
        public void Should_Return_2_Result()
        {
            _result.Should().HaveCount(2);
        }

        [Fact]
        public void Should_Return_Correct_Dates()
        {
            _result.Any(h => h.Date.Equals(new DateTime(2020, 4, 24))).Should().BeTrue();
            _result.Any(h => h.Date.Equals(new DateTime(2020, 9, 8))).Should().BeTrue();
        }
    }
}