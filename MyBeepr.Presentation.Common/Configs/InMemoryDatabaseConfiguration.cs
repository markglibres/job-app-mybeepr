using BizzPo.Core.Domain;
using MyBeepr.Domain.Contacts;
using MyBeepr.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace MyBeepr.Presentation.Common.Configs
{
    public static class InMemoryDatabaseConfiguration
    {
        public static void AddInMemoryDatabase(this IServiceCollection services)
        {
            services.AddTransient<IRepository<Contact>, InMemoryContactRepository>();
        }
    }
}