using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.Runtime.Internal;
using MediatR;

namespace JobBee.Application.Features.Candidate.Commands.DeleteCandidate
{
	public class DeleteCandidateCommand : IRequest<Unit>
	{
		public Guid Id { get; set; }
	}
}
