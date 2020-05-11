using System;
using MediatR;

namespace MyBeepr.Application.Queries.GetWorkingDays
{
    public class GetWorkingDaysCountQuery : IRequest<GetWorkingDaysCountQueryResponse>
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}