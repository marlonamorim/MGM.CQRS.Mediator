using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MGM.CQRS.Mediator.Domain.Commands.Requests;
using MGM.CQRS.Mediator.Domain.Commands.Responses;
using MGM.CQRS.Mediator.Domain.Entities;
using MGM.CQRS.Mediator.Domain.Repositories;
using MGM.CQRS.Mediator.Domain.Services;

namespace MGM.CQRS.Mediator.Domain.Handlers
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerRequest, CreateCustomerResponse>
    {
        ICustomerRepository _customerRepository;
        IEmailService _emailService;

        public CreateCustomerHandler(ICustomerRepository customerRepository, IEmailService emailService)
        {
            _customerRepository = customerRepository;
            _emailService = emailService;
        }

        public CreateCustomerResponse Handle(CreateCustomerRequest command)
        {
             // Aplicar Fail Fast Validations

            // Cria a entidade
            var customer = new Customer(command.Name, command.Email);

            // Persiste a entidade no banco
            _customerRepository.Save(customer);

            // Envia E-mail de boas-vindas
            _emailService.Send(customer.Name, customer.Email);

            // Retorna a resposta
            return new CreateCustomerResponse
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.Email,
                Date = DateTime.Now
            };
        }

        public Task<CreateCustomerResponse> Handle(CreateCustomerRequest request, CancellationToken cancellationToken)
        {
            var customer = new Customer(request.Name, request.Email);

            // Persiste a entidade no banco
            _customerRepository.Save(customer);

            // Envia E-mail de boas-vindas
            _emailService.Send(customer.Name, customer.Email);

            // Retorna a resposta
            var result = new CreateCustomerResponse
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.Email,
                Date = DateTime.Now
            };

            return Task.FromResult(result);
        }
    }
}