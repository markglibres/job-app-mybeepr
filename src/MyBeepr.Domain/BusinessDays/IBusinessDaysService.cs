using System;
using System.Threading.Tasks;

namespace MyBeepr.Domain.BusinessDays
{
    public interface IBusinessDaysService
    {
        Task<int> GetWorkingDays(DateTime startDate, DateTime endDate);
    }
}