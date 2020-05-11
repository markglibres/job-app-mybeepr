using BizzPo.Core.Infrastructure.Repository.InMemory;
using MyBeepr.Domain.Contacts;

namespace MyBeepr.Infrastructure.Repositories
{
    //do your own implementation of IRepository<T>
    //or you can inherit / use from
    //BizzPo.Core.Infrastructure.Repository.InMemory.InMemoryRepository
    public class InMemoryContactRepository : InMemoryRepository<Contact>
    {
    }
}