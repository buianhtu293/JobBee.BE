using FluentValidation;
using JobBee.Application.Contracts.Persistence;
namespace JobBee.Application.Features.SkillCategory.Commands.UpdateSkillCategory
{
	public class UpdateSkillCategoryCommandValidator : AbstractValidator<UpdateSkillCategoryCommand>
	{
		private readonly ISkillCategoryRepository _skillCategoryRepository;

		public UpdateSkillCategoryCommandValidator(ISkillCategoryRepository skillCategoryRepository)
		{
			RuleFor(p => p.CategoryName)
				.NotEmpty().WithMessage("{PropertyName} is required")
				.NotNull()
				.MaximumLength(70).WithMessage("{PropertyName} must be fewer than 70 characters");

			RuleFor(p => p)
				.MustAsync(SkillCategoryNameUnique)
				.WithMessage("Skill Category already exists");

			_skillCategoryRepository = skillCategoryRepository;
		}

		private async Task<bool> SkillCategoryNameUnique(UpdateSkillCategoryCommand command, CancellationToken token)
		{
			var existing = await _skillCategoryRepository.GetByName(command.CategoryName);

			if (existing == null)
				return true;

			return existing.Id == command.Id;
		}
	}
}
