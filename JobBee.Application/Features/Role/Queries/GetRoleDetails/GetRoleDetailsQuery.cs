using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.Role.Queries.GetRoleDetails
{
	public record GetRoleDetailsQuery(Guid id) : IRequest<ApiResponse<RoleDetailsDto>>; 
}
