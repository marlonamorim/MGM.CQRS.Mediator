namespace MGM.CQRS.Mediator.Domain.Services
{
    public interface IEmailService
    {
        void Send(string name, string email);
    }
}