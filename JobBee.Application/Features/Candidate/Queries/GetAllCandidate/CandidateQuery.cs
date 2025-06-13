using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.Runtime.Internal;
using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.Candidate.Queries.GetAllCandidate
{
	public record CandidateQuery : IRequest<ApiResponse<List<CandidateDto>>>;
}
