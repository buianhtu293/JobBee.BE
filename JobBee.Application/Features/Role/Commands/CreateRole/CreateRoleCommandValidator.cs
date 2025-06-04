using FluentValidation;
using JobBee.Application.Contracts.Persistence;

namespace JobBee.Application.Features.Role.Commands.CreateRole
{
	public class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
	{
		private readonly IRoleRepository _roleRepository;

		public CreateRoleCommandValidator(IRoleRepository roleRepository)
		{
			RuleFor(p => p.Name)
				.NotEmpty().WithMessage("{PropertyName} is required")
				.NotNull()
				.MaximumLength(70).WithMessage("{PropertyName} must be fewer than 70 characters");

			RuleFor(p => p)
				.MustAsync(RoleNameUnique)
				.WithMessage("Role already exists");

			_roleRepository = roleRepository;
		}

		private Task<bool> RoleNameUnique(CreateRoleCommand command, CancellationToken token)
		{
			return _roleRepository.IsRoleUnique(command.Name);
		}
	}
}
