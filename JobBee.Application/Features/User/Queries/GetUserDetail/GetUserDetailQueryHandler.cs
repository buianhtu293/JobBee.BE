using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Exceptions;
using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.User.Queries.GetUserDetail
{
	public class GetUserDetailQueryHandler : IRequestHandler<GetUserDetailQuery, ApiResponse<UserDetailDto>>
	{
		private readonly IMapper _mapper;
		private readonly IUserRepository _userRepository;

		public GetUserDetailQueryHandler(IMapper mapper, IUserRepository userRepository)
		{
			_mapper = mapper;
			_userRepository = userRepository;
		}

		public async Task<ApiResponse<UserDetailDto>> Handle(GetUserDetailQuery request, CancellationToken cancellationToken)
		{
			var user = _userRepository.GetById(request.id);

			if (user == null)
			{
				throw new NotFoundException(nameof(user), request.id);
			}

			var userDetail = _mapper.Map<UserDetailDto>(user);
			var data = new ApiResponse<UserDetailDto>("Success", 200, userDetail);

			return data;
		}
	}
}
