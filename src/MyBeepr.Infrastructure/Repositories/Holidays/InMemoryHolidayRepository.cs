using System.Collections.Generic;
using System.Linq;
using BizzPo.Core.Infrastructure.Repository.InMemory;
using MyBeepr.Domain.Holidays.Entities;

namespace MyBeepr.Infrastructure.Repositories.Holidays
{
    public class InMemoryFixedDayRepository : InMemoryRepository<FixedDayHoliday>
    {
        public InMemoryFixedDayRepository(IEnumerable<FixedDayHoliday> initialItems)
        {
            var itemsToInsert = initialItems.ToList();

            if (!itemsToInsert.Any()) return;

            itemsToInsert.ForEach(item => InsertAsync(item).Wait());
        }
    }
}