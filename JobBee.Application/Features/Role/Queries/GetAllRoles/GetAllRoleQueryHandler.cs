using AutoMapper;
using JobBee.Application.Contracts.Logging;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.Role.Queries.GetAllRoles
{
    public class GetAllRoleQueryHandler : IRequestHandler<GetAllRoleQuery, ApiResponse<List<RoleDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IRoleRepository _roleRepository;
        private readonly IAppLogger<GetAllRoleQueryHandler> _logger;

        public GetAllRoleQueryHandler(IMapper mapper,
            IRoleRepository roleRepository,
            IAppLogger<GetAllRoleQueryHandler> logger)
        {
            _mapper = mapper;
            _roleRepository = roleRepository;
            _logger = logger;
        }

        public async Task<ApiResponse<List<RoleDto>>> Handle(GetAllRoleQuery request, CancellationToken cancellationToken)
        {
            var roles = await _roleRepository.GetAllListAsync();

            var roleLists = _mapper.Map<List<RoleDto>>(roles);
            var data = new ApiResponse<List<RoleDto>>("Success", 200, roleLists);

            return data;
        }
    }
}
