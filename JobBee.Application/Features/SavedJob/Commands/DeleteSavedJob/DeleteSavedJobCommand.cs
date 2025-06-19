using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace JobBee.Application.Features.SavedJob.Commands.DeleteSavedJob
{
	public class DeleteSavedJobCommand : IRequest<Unit>
	{
		public Guid CandidateId { get; set; }
		public Guid JobId { get; set; }
	}
}
