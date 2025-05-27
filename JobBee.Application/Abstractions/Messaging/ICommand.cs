using JobBee.Shared.Shared;
using MediatR;

namespace JobBee.Application.Abstractions.Messaging
{
	public interface ICommand : IRequest<Result>
	{
	}

	public interface ICommand<TResponse> : IRequest<Result<TResponse>>
	{
	}
}
