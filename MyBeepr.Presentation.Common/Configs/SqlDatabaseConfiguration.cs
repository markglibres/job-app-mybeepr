using BizzPo.Core.Domain;
using MyBeepr.Domain.Contacts;
using MyBeepr.Infrastructure.Repositories;
using MyBeepr.Infrastructure.Repositories.EfSql;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MyBeepr.Presentation.Common.Configs
{
    public static class SqlDatabaseConfiguration
    {
        public static void AddSqlDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ContactsDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<IRepository<Contact>, ContactsRepository>();
        }
    }
}