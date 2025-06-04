using AutoMapper;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Exceptions;
using MediatR;

namespace JobBee.Application.Features.Role.Commands.DeleteRole
{
	public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand, Unit>
	{
		private readonly IMapper _mapper;
		private readonly IRoleRepository _roleRepository;
		private readonly IUnitOfWork<Domain.Entities.Role, Guid> _unitOfWork;

		public DeleteRoleCommandHandler(IMapper mapper,
			IRoleRepository roleRepository,
			IUnitOfWork<Domain.Entities.Role, Guid> unitOfWork)
		{
			_mapper = mapper;
			_roleRepository = roleRepository;
			_unitOfWork = unitOfWork;
		}

		public async Task<Unit> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
		{
			var roleToDelete = _roleRepository.GetById(request.Id);

			if (roleToDelete == null)
			{
				throw new NotFoundException(nameof(Domain.Entities.Role), request.Id);
			}

			_roleRepository.Delete(roleToDelete);

			await _unitOfWork.SaveChangesAsync();

			return Unit.Value;
		}
	}
}
