using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.CandidateResume.Queries.GetCandidateResumeDetail
{
	public record GetCandidateResumeDetailQuery(Guid id) : IRequest<ApiResponse<CandidateResumeDetailDto>>;
}
