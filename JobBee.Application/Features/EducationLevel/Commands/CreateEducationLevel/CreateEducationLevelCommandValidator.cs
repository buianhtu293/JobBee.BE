using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using JobBee.Application.Contracts.Persistence;

namespace JobBee.Application.Features.EducationLevel.Commands.CreateEducationLevel
{
    public class CreateEducationLevelCommandValidator : AbstractValidator<CreateEducationLevelCommand>
    {
        private readonly IEducationLevelRepository _educationLevelRepository;

        public CreateEducationLevelCommandValidator(IEducationLevelRepository educationLevelRepository)
        {
            RuleFor(p => p.LevelName)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(70).WithMessage("{PropertyName} must be fewer than 70 characters");

            RuleFor(p => p)
                .MustAsync(IsEducationLevelNameUnique)
                .WithMessage("Education Level already exists");

            _educationLevelRepository = educationLevelRepository;
        }

        private Task<bool> IsEducationLevelNameUnique(CreateEducationLevelCommand command, CancellationToken token)
        {
            return _educationLevelRepository.IsEducationLevelUnique(command.LevelName);
        }

    }
}
