using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.Skill.Commands.AddSkill
{
	public class CreateSkillCommand : IRequest<ApiResponse<CreateSkillDto>>
	{
		public string SkillName { get; set; } = null!;
		public Guid? CategoryId { get; set; }
	}
}
