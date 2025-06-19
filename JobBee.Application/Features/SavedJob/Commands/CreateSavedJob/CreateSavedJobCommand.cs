using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.SavedJob.Commands.CreateSavedJob
{
	public class CreateSavedJobCommand : IRequest<ApiResponse<CreateSavedJobDto>>
	{
		public Guid CandidateId { get; set; }
		public Guid JobId { get; set; }
	}
}
