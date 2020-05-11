using AutoFixture;
using Moq;
using MyBeepr.Domain.BusinessDays;
using MyBeepr.Domain.Holidays;
using MyBeepr.Tests;

namespace MyBeepr.Domain.Tests.BusinessDaysTests
{
    public abstract class GivenBusinessDaysService : TestSpecification
    {
        protected BusinessDaysService BusinessDaysService { get; private set; }
        protected Mock<IHolidayService> MockHolidayService { get; set; }

        public override void Given()
        {
            MockHolidayService = Fixture.FreezeMoq<IHolidayService>();
            BusinessDaysService = Fixture.Create<BusinessDaysService>();
        }

    }
}