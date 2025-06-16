using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.Skill.Queries.GetSkillById
{
	public record GetSkillDetailQuery(Guid id) : IRequest<ApiResponse<SkillDetailDto>>;
}
