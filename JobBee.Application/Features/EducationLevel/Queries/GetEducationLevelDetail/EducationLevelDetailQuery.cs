using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.EducationLevel.Queries.GetEducationLevelDetail
{
	public record EducationLevelDetailQuery(Guid id) : IRequest<ApiResponse<EducationLevelDetailDto>>;
}
