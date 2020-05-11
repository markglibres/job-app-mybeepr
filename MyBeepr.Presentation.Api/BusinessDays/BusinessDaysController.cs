using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyBeepr.Application.Queries.GetWorkingDays;

namespace MyBeepr.Presentation.Api.BusinessDays
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessDaysController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BusinessDaysController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetWorkingDays([FromQuery] GetWorkingDaysCountRequest request)
        {
            var query = new GetWorkingDaysCountQuery
            {
                Start = request.Start,
                End = request.End
            };

            var result = await _mediator.Send(query);

            var httpResponse = new GetWorkingDaysCountResponse
            {
                Total = result.Total
            };

            return Ok(httpResponse);
        }
    }
}