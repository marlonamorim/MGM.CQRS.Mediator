using MGM.CQRS.Mediator.Domain.Commands.Requests;
using MGM.CQRS.Mediator.Domain.Commands.Responses;

namespace MGM.CQRS.Mediator.Domain.Handlers
{
    public interface ICreateCustomerHandler
    {
        CreateCustomerResponse Handle(CreateCustomerRequest command);
    }
}