using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace JobBee.Application.Features.ExperienceLevel.Commands.DeleteExperienceLevel
{
	public class DeleteExperienceLevelCommand : IRequest<Unit>
	{
		public Guid Id { get; set; }
	}
}
