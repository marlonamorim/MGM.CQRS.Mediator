using MGM.CQRS.Mediator.Domain.Queries.Requests;
using MGM.CQRS.Mediator.Domain.Queries.Responses;

namespace MGM.CQRS.Mediator.Domain.Handlers
{
    public interface IFindCustomerByIdHandler
    {
        FindCustomerByIdResponse Handle(FindCustomerByIdRequest command);
    }
}