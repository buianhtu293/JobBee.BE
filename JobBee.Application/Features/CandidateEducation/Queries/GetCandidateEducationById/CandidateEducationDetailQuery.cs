using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.CandidateEducation.Queries.GetCandidateEducationById
{
	public record CandidateEducationDetailQuery(Guid id) : IRequest<ApiResponse<CandidateEducationDetailDto>>;
}
