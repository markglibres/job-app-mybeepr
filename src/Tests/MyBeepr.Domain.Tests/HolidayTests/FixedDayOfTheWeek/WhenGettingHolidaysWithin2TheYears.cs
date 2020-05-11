using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using MyBeepr.Domain.Holidays;
using Xunit;

namespace MyBeepr.Domain.Tests.HolidayTests.FixedDayOfTheWeek
{
    public class WhenGettingHolidaysWithin2TheYears : GivenFixedDayOfTheWeekHolidayService
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
        public void Should_Return_Correct_Date()
        {
            _result.Any(h => h.Date.Equals(new DateTime(2020, 5, 13))).Should().BeTrue();
            _result.Any(h => h.Date.Equals(new DateTime(2020, 6, 8))).Should().BeTrue();
            _result.Any(h => h.Date.Equals(new DateTime(2021, 5, 12))).Should().BeTrue();
            _result.Any(h => h.Date.Equals(new DateTime(2021, 6, 14))).Should().BeTrue();
           
        }

    }
}