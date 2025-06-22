using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace JobBee.Application.Features.SavedCandidate.Commands.DeleteSavedCandidate
{
	public class DeleteSavedCandidateCommand : IRequest<Unit>
	{
		public Guid EmployerId { get; set; }
		public Guid CandidateId { get; set; }
	}
}
