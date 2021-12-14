using System;

namespace MGM.CQRS.Mediator.Domain.Queries.Responses
{
    public class FindCustomerByIdResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}