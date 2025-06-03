using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobBee.Shared.Shared;
using MediatR;

namespace JobBee.Application.Abstractions.Messaging
{
	public interface IQueryHandler<TQuery, TResponse>
	: IRequestHandler<TQuery, Result<TResponse>>
	where TQuery : IQuery<TResponse>
	{
	}
}
