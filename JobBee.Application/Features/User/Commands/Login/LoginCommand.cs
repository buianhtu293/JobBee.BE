using JobBee.Application.Abstractions.Messaging;

namespace JobBee.Application.Features.User.Commands.Login
{
    public record LoginCommand(string email, string password) : ICommand<string>;
}
