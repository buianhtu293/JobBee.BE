using AutoMapper;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Exceptions;
using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.Role.Commands.CreateRole
{
	public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, ApiResponse<CreateRoleDto>>
	{
		private readonly IMapper _mapper;
		private readonly IRoleRepository _roleRepository;
		private readonly IUnitOfWork<Domain.Entities.Role, Guid> _unitOfWork;

		public CreateRoleCommandHandler(IMapper mapper,
			IRoleRepository roleRepository,
			IUnitOfWork<Domain.Entities.Role, Guid> unitOfWork)
		{
			_mapper = mapper;
			_roleRepository = roleRepository;
			_unitOfWork = unitOfWork;
		}

		public async Task<ApiResponse<CreateRoleDto>> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
		{
			var validator = new CreateRoleCommandValidator(_roleRepository);
			var validatorResult = await validator.ValidateAsync(request);

			if (validatorResult.Errors.Any())
			{
				throw new BadRequestException("Invalid role", validatorResult);
			}

			var roleToCreate = _mapper.Map<Domain.Entities.Role>(request);
			roleToCreate.Id = Guid.NewGuid();
			roleToCreate.NormalizedName = request.Name.ToUpper();
			roleToCreate.ConcurrencyStamp = null;

			_roleRepository.Insert(roleToCreate);

			var roleToCreated = _mapper.Map<CreateRoleDto>(roleToCreate);
			var data = new ApiResponse<CreateRoleDto>("Success", 201, roleToCreated);

			await _unitOfWork.SaveChangesAsync();

			return data;
		}
	}
}
