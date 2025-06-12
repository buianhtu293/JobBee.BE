using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.Runtime.Internal;
using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.CandidateEducation.Queries.GetAllCandidateEducation
{
	public record CandidateEducationQuery : IRequest<ApiResponse<List<CandidateEducationDto>>>;
}
