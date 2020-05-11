using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;

namespace MyBeepr.Tests
{
    public abstract class TestSpecification
    {
        protected IFixture Fixture { get; private set; }
        public TestSpecification()
        {
            Fixture = new Fixture().Customize(new AutoMoqCustomization());
            Given();
            GivenAsync().Wait();
            When();
            WhenAsync().Wait();
           
        }

        public virtual void Given()
        {
        }

        public virtual Task GivenAsync()
        {
            return Task.CompletedTask;
        }

        public virtual void When()
        {
        }

        public virtual Task WhenAsync()
        {
            return Task.CompletedTask;
        }
    }
}