using System;
using MediatR;

namespace MyBeepr.Application.Queries.GetContact
{
    public class GetContactQuery : IRequest<GetContactQueryResponse>
    {
        public Guid ContactId { get; set; }
    }
}