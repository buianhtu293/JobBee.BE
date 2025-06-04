using AutoMapper;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Exceptions;
using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.Role.Commands.UpdateRole
{
	public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand, ApiResponse<UpdateRoleDto>>
	{
		private readonly IMapper _mapper;
		private readonly IRoleRepository _roleRepository;
		private readonly IUnitOfWork<Domain.Entities.Role, Guid> _unitOfWork;

		public UpdateRoleCommandHandler(IMapper mapper,
			IRoleRepository roleRepository,
			IUnitOfWork<Domain.Entities.Role, Guid> unitOfWork)
		{
			_mapper = mapper;
			_roleRepository = roleRepository;
			_unitOfWork = unitOfWork;
		}

		public async Task<ApiResponse<UpdateRoleDto>> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
		{
			var validator = new UpdateRoleCommandValidator(_roleRepository);
			var validatorResult = await validator.ValidateAsync(request);

			if (validatorResult.Errors.Any())
			{
				throw new BadRequestException("Invalid Role", validatorResult);
			}

			var roleToUpdate = _mapper.Map<Domain.Entities.Role>(request);
			roleToUpdate.NormalizedName = request.Name.ToUpper();

			_roleRepository.Update(roleToUpdate);

			var roleUpdated = _mapper.Map<UpdateRoleDto>(roleToUpdate);
			var data = new ApiResponse<UpdateRoleDto>("Success", 200, roleUpdated);

			await _unitOfWork.SaveChangesAsync();

			return data;
		}
	}
}
