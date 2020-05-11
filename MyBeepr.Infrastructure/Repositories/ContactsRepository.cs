using BizzPo.Core.Infrastructure.Repository.EntityFramework;
using MyBeepr.Domain.Contacts;
using MyBeepr.Infrastructure.Repositories.EfSql;

namespace MyBeepr.Infrastructure.Repositories
{
    //do your own implementation of IRepository<T>
    //or you can inherit / use from
    //BizzPo.Core.Infrastructure.Repository.EntityFramework.SqlRepository
    public class ContactsRepository : SqlRepository<Contact>
    {
        public ContactsRepository(ContactsDbContext dbContext) : base(dbContext)
        {
        }
    }
}