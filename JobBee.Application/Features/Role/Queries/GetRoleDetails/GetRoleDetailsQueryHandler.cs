using AutoMapper;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Exceptions;
using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.Role.Queries.GetRoleDetails
{
	public class GetRoleDetailsQueryHandler : IRequestHandler<GetRoleDetailsQuery, ApiResponse<RoleDetailsDto>>
	{
		private readonly IMapper _mapper;
		private readonly IRoleRepository _roleRepository;

		public GetRoleDetailsQueryHandler(IMapper mapper,
			IRoleRepository roleRepository)
		{
			_mapper = mapper;
			_roleRepository = roleRepository;
		}

		public async Task<ApiResponse<RoleDetailsDto>> Handle(GetRoleDetailsQuery request, CancellationToken cancellationToken)
		{
			var role = _roleRepository.GetById(request.id);

			if(role == null)
			{
				throw new NotFoundException(nameof(role), request.id);
			}

			var roleDetail = _mapper.Map<RoleDetailsDto>(role);
			var data = new ApiResponse<RoleDetailsDto>("Success", 200, roleDetail);

			return data;
		}
	}
}
