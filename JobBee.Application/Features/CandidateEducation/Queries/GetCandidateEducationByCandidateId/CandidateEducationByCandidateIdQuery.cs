using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.Runtime.Internal;
using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.CandidateEducation.Queries.GetCandidateEducationByCandidateId
{
	public record CandidateEducationByCandidateIdQuery(Guid id) : IRequest<ApiResponse<List<CandidateEducationByCandidateIdDto>>>;
}
