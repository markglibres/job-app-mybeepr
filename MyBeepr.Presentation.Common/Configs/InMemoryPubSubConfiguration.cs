using BizzPo.Core.Application;
using MyBeepr.Application.Integration.Publish;
using MyBeepr.Application.Integration.Subscribe.AccountCreated;
using MyBeepr.Infrastructure.Messaging.InMemoryPubSub;
using Microsoft.Extensions.DependencyInjection;

namespace MyBeepr.Presentation.Common.Configs
{
    public static class InMemoryPubSubConfiguration
    {
        public static void AddInMemoryPublishEvents(this IServiceCollection services)
        {
            services
                .AddTransient<IIntegrationEventPublisherService<ContactAddedEvent>,
                    InMemoryPublisherService<ContactAddedEvent>>();
        }

        public static void AddInMemorySubscribeEvents(this IServiceCollection services)
        {
            services.AddTransient<IIntegrationEventSubscriberService<AccountCreatedEvent>,
                InMemorySubscriberService<AccountCreatedEvent>>();
        }
    }
}