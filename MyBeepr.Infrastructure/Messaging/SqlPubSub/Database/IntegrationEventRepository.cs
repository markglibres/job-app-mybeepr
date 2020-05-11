using BizzPo.Core.Infrastructure.Repository.EntityFramework;

namespace MyBeepr.Infrastructure.Messaging.SqlPubSub.Database
{
    public class IntegrationEventRepository : SqlRepository<PubSubEvent>
    {
        public IntegrationEventRepository(IntegrationEventDbContext dbContext) 
            : base(dbContext)
        {
        }
    }
}