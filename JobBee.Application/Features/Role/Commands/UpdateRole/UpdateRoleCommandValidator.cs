using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using JobBee.Application.Contracts.Persistence;

namespace JobBee.Application.Features.Role.Commands.UpdateRole
{
    public class UpdateRoleCommandValidator : AbstractValidator<UpdateRoleCommand>
    {
        private readonly IRoleRepository _roleRepository;

        public UpdateRoleCommandValidator(IRoleRepository roleRepository)
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(70).WithMessage("{PropertyName} must be fewer than 70 characters");

            RuleFor(p => p)
                .MustAsync(RoleNameUnique)
                .WithMessage("Role already exist");

            _roleRepository = roleRepository;
        }

        private async Task<bool> RoleNameUnique(UpdateRoleCommand command, CancellationToken token)
        {
            var existing = await _roleRepository.GetByName(command.Name);

            if (existing == null)
            {
                return true;
            }

            return existing.Id == command.Id;

        }
    }
}
