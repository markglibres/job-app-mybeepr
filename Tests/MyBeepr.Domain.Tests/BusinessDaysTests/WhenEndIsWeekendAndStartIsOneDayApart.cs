using System;
using FluentAssertions;
using Xunit;

namespace MyBeepr.Domain.Tests.BusinessDaysTests
{
    public class WhenEndIsWeekendAndStartIsOneDayApart : GivenBusinessDaysService
    {
        private int _result;

        public override void When()
        {
            var startDate = new DateTime(2020, 5, 8);
            var endDate = new DateTime(2020, 5, 9);
            _result = BusinessDaysService.GetWorkingDays(startDate, endDate);
        }

        [Fact]
        public void Should_Return_0_Working_Days()
        {
            _result.Should().Be(0);
        }
    }
}