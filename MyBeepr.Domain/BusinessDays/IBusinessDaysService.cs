using System;

namespace MyBeepr.Domain.BusinessDays
{
    public interface IBusinessDaysService
    {
        int GetWorkingDays(DateTime startDate, DateTime endDate);
    }
}