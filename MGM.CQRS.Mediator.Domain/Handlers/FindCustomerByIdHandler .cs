using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MGM.CQRS.Mediator.Domain.Queries.Requests;
using MGM.CQRS.Mediator.Domain.Queries.Responses;
using MGM.CQRS.Mediator.Domain.Repositories;

namespace MGM.CQRS.Mediator.Domain.Handlers
{
    public class FindCustomerByIdHandler : IRequestHandler<FindCustomerByIdRequest, FindCustomerByIdResponse>
    {
        ICustomerRepository _repository;

        public FindCustomerByIdHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public Task<FindCustomerByIdResponse> Handle(FindCustomerByIdRequest request, CancellationToken cancellationToken)
        {
            // TODO: Lógica de leitura se houver

            // Retorna o resultado
            var result = _repository.GetCustomerById(request.Id);

            return Task.FromResult(result);
        }
    }
}