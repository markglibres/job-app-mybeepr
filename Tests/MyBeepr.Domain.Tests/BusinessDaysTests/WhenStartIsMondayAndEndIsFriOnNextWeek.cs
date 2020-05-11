using System;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace MyBeepr.Domain.Tests.BusinessDaysTests
{
    public class WhenStartIsMondayAndEndIsFriOnNextWeek : GivenBusinessDaysService
    {
        private int _result;

        public override async Task WhenAsync()
        {
            var startDate = new DateTime(2020, 5, 4);
            var endDate = new DateTime(2020, 5, 15);
            _result = await BusinessDaysService.GetWorkingDays(startDate, endDate);
        }

        [Fact]
        public void Should_Return_8_Working_Days()
        {
            _result.Should().Be(8);
        }
    }
}