
using MediatR;

namespace JobBee.Application.Features.Skill.Commands.DeleteSkill
{
	public class DeleteSkillCommand : IRequest<Unit>
	{
		public Guid Id { get; set; }
	}
}
