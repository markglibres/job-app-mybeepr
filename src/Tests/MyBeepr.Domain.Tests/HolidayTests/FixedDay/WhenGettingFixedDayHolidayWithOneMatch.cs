﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using MyBeepr.Domain.Holidays;
using Xunit;

namespace MyBeepr.Domain.Tests.HolidayTests.FixedDay
{
    public class WhenGettingFixedDayHolidayWithOneMatch : GivenFixedDayHolidayService
    {
        private IEnumerable<Holiday> _result;

        public override async Task WhenAsync()
        {
            _result = await HolidayService.GetHolidays(
                new DateTime(2020, 4, 1),
                new DateTime(2020, 4, 28));
        }

        [Fact]
        public void Should_Not_Return_Empty_Collection()
        {
            _result.Should().NotBeEmpty();
        }

        [Fact]
        public void Should_Return_1_Result()
        {
            _result.Should().HaveCount(1);
        }

        [Fact]
        public void Should_Return_Correct_Date()
        {
            _result.Single().Date.Date.Should().Be(new DateTime(2020, 4, 24));
        }
    }
}