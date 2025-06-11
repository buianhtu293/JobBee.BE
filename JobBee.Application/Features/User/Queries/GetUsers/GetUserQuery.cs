using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobBee.Application.Features.User.Queries.GetAllUser;
using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.User.Queries.GetUsers
{
	public record GetUserQuery : IRequest<ApiResponse<List<UserDto>>>;
}
