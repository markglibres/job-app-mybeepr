using System;
using FluentAssertions;
using Xunit;

namespace MyBeepr.Domain.Tests.BusinessDaysTests
{
    public class WhenStartIsSundayAndEndIsSatOnNextWeek : GivenBusinessDaysService
    {
        private int _result;

        public override void When()
        {
            var startDate = new DateTime(2020, 5, 3);
            var endDate = new DateTime(2020, 5, 16);
            _result = BusinessDaysService.GetWorkingDays(startDate, endDate);
        }

        [Fact]
        public void Should_Return_10_Working_Days()
        {
            _result.Should().Be(10);
        }
    }
}