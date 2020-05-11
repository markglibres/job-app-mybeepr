using System;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace MyBeepr.Domain.Tests.BusinessDaysTests
{
    public class WhenEndDateIsLessThanStartDate : GivenBusinessDaysService
    {
        private int _result;

        public override async Task WhenAsync()
        {
            _result = await BusinessDaysService
                .GetWorkingDays(DateTime.Now.AddDays(4), DateTime.Now.AddDays(3));
        }

        [Fact]
        public void Should_Return_0()
        {
            _result.Should().Be(0);
        }
    }
}