using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.Skill.Commands.UpdateSkill
{
	public class UpdateSkillCommand : IRequest<ApiResponse<UpdateSkillDto>>
	{
		public Guid Id { get; set; }
		public string SkillName { get; set; } = null!;
		public Guid? CategoryId { get; set; }
	}
}
