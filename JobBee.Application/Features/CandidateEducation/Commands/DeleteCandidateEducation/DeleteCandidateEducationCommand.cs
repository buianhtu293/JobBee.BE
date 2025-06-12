using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.Runtime.Internal;
using MediatR;

namespace JobBee.Application.Features.CandidateEducation.Commands.DeleteCandidateEducation
{
	public class DeleteCandidateEducationCommand : IRequest<Unit>
	{
		public Guid Id { get; set; }
	}
}
