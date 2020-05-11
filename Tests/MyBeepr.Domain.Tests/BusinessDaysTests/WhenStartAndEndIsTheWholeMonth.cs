using System;
using FluentAssertions;
using Xunit;

namespace MyBeepr.Domain.Tests.BusinessDaysTests
{
    public class WhenStartAndEndIsTheWholeMonth : GivenBusinessDaysService
    {
        private int _result;

        public override void When()
        {
            var startDate = new DateTime(2020, 5, 1);
            var endDate = new DateTime(2020, 5, 31);
            _result = BusinessDaysService.GetWorkingDays(startDate, endDate);
        }

        [Fact]
        public void Should_Return_20_Working_Days()
        {
            _result.Should().Be(20);
        }
    }
}