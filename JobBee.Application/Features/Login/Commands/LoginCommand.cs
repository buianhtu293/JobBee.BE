using JobBee.Application.Abstractions.Messaging;

namespace JobBee.Application.Features.Login.Commands
{
	public record LoginCommand(string email) : ICommand<string>;
}
