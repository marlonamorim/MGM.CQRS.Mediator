using System;
using MGM.CQRS.Mediator.Domain.Entities;
using MGM.CQRS.Mediator.Domain.Queries.Responses;

namespace MGM.CQRS.Mediator.Domain.Repositories
{
    public interface ICustomerRepository
    {
         void Save(Customer entity);
         FindCustomerByIdResponse GetCustomerById(Guid Id);
    }
}