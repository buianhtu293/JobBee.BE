using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobBee.Shared.Shared;
using MediatR;

namespace JobBee.Application.Abstractions.Messaging
{
	public interface IQuery<TResponse> : IRequest<Result<TResponse>>
	{
	}
}
