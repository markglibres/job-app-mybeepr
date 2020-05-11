using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace MyBeepr.Domain.Tests.BusinessDaysTests
{
    public class WhenStartIsTuesdayAndEndIsThursOnNextWeek : GivenBusinessDaysService
    {
        private int _result;

        public override async Task WhenAsync()
        {
            var startDate = new DateTime(2020, 5, 5);
            var endDate = new DateTime(2020, 5, 14);
            _result = await BusinessDaysService.GetWorkingDays(startDate, endDate);
        }

        [Fact]
        public void Should_Return_6_Working_Days()
        {
            _result.Should().Be(6);
        }
    }
}
