using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using JobBee.Application.Contracts.Persistence;

namespace JobBee.Application.Features.SkillCategory.Commands.CreateSkillCategory
{
	public class CreateSkillCategoryCommandValidator : AbstractValidator<CreateSkillCategoryCommand>
	{
		private readonly ISkillCategoryRepository _skillCategoryRepository;

		public CreateSkillCategoryCommandValidator(ISkillCategoryRepository skillCategoryRepository)
		{

			RuleFor(p => p.CategoryName)
				.NotEmpty().WithMessage("{PropertyName} is required")
				.NotNull()
				.MaximumLength(70).WithMessage("{PropertyName} must be fewer than 70 characters");

			//RuleFor(p => p)
			//	.MustAsync(SkillCategoryNameUnique)
			//	.WithMessage("Skill Category already exists");

			_skillCategoryRepository = skillCategoryRepository;
		}

		private Task<bool> SkillCategoryNameUnique(CreateSkillCategoryCommand command, CancellationToken token)
		{
			return _skillCategoryRepository.IsSkillCategoryUnique(command.CategoryName);
		}
	}
}
