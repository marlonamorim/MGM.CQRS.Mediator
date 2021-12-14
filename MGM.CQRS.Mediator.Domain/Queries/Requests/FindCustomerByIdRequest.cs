using System;
using MediatR;
using MGM.CQRS.Mediator.Domain.Queries.Responses;

namespace MGM.CQRS.Mediator.Domain.Queries.Requests
{
    public class FindCustomerByIdRequest : IRequest<FindCustomerByIdResponse>
    {
        public Guid Id { get; set; }
    }
}