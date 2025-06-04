using MediatR;

namespace JobBee.Application.Features.Role.Commands.DeleteRole
{
	public class DeleteRoleCommand : IRequest<Unit>
	{
		public Guid Id { get; set; }
	}
}
