using MediatR;
using MGM.CQRS.Mediator.Domain.Commands.Responses;

namespace MGM.CQRS.Mediator.Domain.Commands.Requests
{
    public class CreateCustomerRequest : IRequest<CreateCustomerResponse>
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}