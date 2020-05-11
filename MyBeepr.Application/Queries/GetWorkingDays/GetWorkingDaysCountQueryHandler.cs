using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using MyBeepr.Domain.BusinessDays;

namespace MyBeepr.Application.Queries.GetWorkingDays
{
    public class GetWorkingDaysCountQueryHandler
        : IRequestHandler<GetWorkingDaysCountQuery, GetWorkingDaysCountQueryResponse>
    {
        private readonly IBusinessDaysService _businessDaysService;
        private readonly ILogger<GetWorkingDaysCountQueryHandler> _logger;

        public GetWorkingDaysCountQueryHandler(
            ILogger<GetWorkingDaysCountQueryHandler> logger,
            IBusinessDaysService businessDaysService)
        {
            _logger = logger;
            _businessDaysService = businessDaysService;
        }

        public async Task<GetWorkingDaysCountQueryResponse> Handle(GetWorkingDaysCountQuery request,
            CancellationToken cancellationToken)
        {
            var count = await _businessDaysService.GetWorkingDays(
                request.Start,
                request.End);

            return new GetWorkingDaysCountQueryResponse
            {
                Total = count
            };
        }
    }
}