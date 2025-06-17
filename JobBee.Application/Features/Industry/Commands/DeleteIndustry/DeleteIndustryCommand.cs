using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace JobBee.Application.Features.Industry.Commands.DeleteIndustry
{
	public class DeleteIndustryCommand : IRequest<Unit>
	{
		public Guid Id { get; set; }
	}
}
