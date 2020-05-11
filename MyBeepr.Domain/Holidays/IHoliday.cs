namespace MyBeepr.Domain.Holidays.Entities
{
    public interface IHoliday
    {
        HolidayTypes HolidayType { get; }
        bool IsDisabled { get; }
        string Name { get; }
    }
}