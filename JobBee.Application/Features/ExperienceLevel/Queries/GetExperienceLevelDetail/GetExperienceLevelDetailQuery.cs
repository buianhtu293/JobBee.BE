using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.ExperienceLevel.Queries.GetExperienceLevelDetail
{
	public record GetExperienceLevelDetailQuery(Guid id) : IRequest<ApiResponse<ExperienceLevelDetailDto>>;
}
