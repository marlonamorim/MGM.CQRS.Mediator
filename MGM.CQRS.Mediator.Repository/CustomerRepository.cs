using System;
using MGM.CQRS.Mediator.Domain.Entities;
using MGM.CQRS.Mediator.Domain.Queries.Responses;
using MGM.CQRS.Mediator.Domain.Repositories;

namespace MGM.CQRS.Mediator.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        public FindCustomerByIdResponse GetCustomerById(Guid Id)
        {
            return new FindCustomerByIdResponse {
                Email = "marlon.mgm@io.com",
                Name = "Marlon Graciano",
                Id = Id
            };
        }

        public void Save(Customer entity)
        {
        }
    }
}