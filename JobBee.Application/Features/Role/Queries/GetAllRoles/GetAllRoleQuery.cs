using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.Role.Queries.GetAllRoles
{
    public record GetAllRoleQuery : IRequest<ApiResponse<List<RoleDto>>>;
}
