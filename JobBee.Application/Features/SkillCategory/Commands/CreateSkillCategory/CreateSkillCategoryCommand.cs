using JobBee.Application.Features.SkillCategory.Queries.GetAllSkillCategories;
using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.SkillCategory.Commands.CreateSkillCategory
{
	public class CreateSkillCategoryCommand : IRequest<ApiResponse<SkillCategoryDto>>
	{
		public string CategoryName { get; set; } = null!;
	}
}
