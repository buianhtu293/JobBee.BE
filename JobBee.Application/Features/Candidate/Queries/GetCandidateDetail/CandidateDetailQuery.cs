using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.Candidate.Queries.GetCandidateDetail
{
	public record CandidateDetailQuery(Guid id) : IRequest<ApiResponse<CandidateDetailDto>>;
}
