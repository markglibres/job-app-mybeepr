using System;
using Microsoft.AspNetCore.Mvc;

namespace MyBeepr.Presentation.Api.BusinessDays
{
    public class GetWorkingDaysCountRequest
    {
        [FromQuery] public DateTime Start { get; set; }

        [FromQuery] public DateTime End { get; set; }
    }
}