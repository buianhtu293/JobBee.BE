using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobBee.Application.Models.Response;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace JobBee.Application.Features.CandidateResume.Commands.CreateCandidateResume
{
	public class CreateCandidateResumeCommand : IRequest<ApiResponse<bool>>
	{
		public Guid CandidateId { get; set; }
		public IFormFile Resume { get; set; } = null!;
	}
}
