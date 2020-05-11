using BizzPo.Core.Domain;
using BizzPo.Core.Infrastructure.Messaging.MediatR;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyBeepr.Application.Queries.GetWorkingDays;

namespace MyBeepr.Presentation.Api.Configs
{
    public static class ServicesConfiguration
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(typeof(GetWorkingDaysCountQueryHandler).Assembly);

            services.AddTransient<IDomainEventsService, MediatrDomainEventsService>();
        }
    }
}