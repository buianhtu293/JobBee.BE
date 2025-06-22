using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.SavedCandidate.Commands.CreateSavedCandidate
{
	public class CreateSavedCandidateCommand : IRequest<ApiResponse<CreateSavedCandidateDto>>
	{
		public Guid EmployerId { get; set; }
		public Guid CandidateId { get; set; }
		public string? Notes { get; set; }
	}
}
