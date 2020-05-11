using MyBeepr.Domain.BusinessDays;
using MyBeepr.Tests;

namespace MyBeepr.Domain.Tests.BusinessDaysTests
{
    public abstract class GivenBusinessDaysService : TestSpecification
    {
        protected BusinessDaysService BusinessDaysService { get; private set; }

        public override void Given()
        {
            BusinessDaysService = new BusinessDaysService();
        }
    }
}