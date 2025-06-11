using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Features.User.Queries.GetAllUser;
using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.User.Queries.GetUsers
{
	public class GetUserQueryHandler : IRequestHandler<GetUserQuery, ApiResponse<List<UserDto>>>
	{
		private readonly IMapper _mapper;
		private readonly IUserRepository _userRepository;

		public GetUserQueryHandler(IMapper mapper, IUserRepository userRepository)
		{
			_mapper = mapper;
			_userRepository = userRepository;
		}

		public async Task<ApiResponse<List<UserDto>>> Handle(GetUserQuery request, CancellationToken cancellationToken)
		{
			var users = await _userRepository.GetAllListAsync();

			var userList = _mapper.Map<List<UserDto>>(users);
			var data = new ApiResponse<List<UserDto>>("Success", 200, userList);

			return data;
		}
	}
}
