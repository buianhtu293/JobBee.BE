using JobBee.Application.Models.Response;
using JobBee.Shared.Paginators;
using MediatR;

namespace JobBee.Application.Features.User.Queries.GetAllUser
{
	public class GetAllUserQuery : IRequest<ApiResponse<PageResult<UserDto>>>
	{
		public string? UserName { get; set; }
		public string? Email { get; set; }
		public string? PhoneNumber { get; set; }
		public int Page { get; set; } = 0;
		public int PageSize { get; set; } = 20;
	}
}
