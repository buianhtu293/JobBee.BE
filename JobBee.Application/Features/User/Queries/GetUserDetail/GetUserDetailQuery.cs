using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.User.Queries.GetUserDetail
{
	public record GetUserDetailQuery(Guid id) : IRequest<ApiResponse<UserDetailDto>>;
}
