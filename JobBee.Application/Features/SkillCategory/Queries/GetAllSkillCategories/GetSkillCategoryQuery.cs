using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.SkillCategory.Queries.GetAllSkillCategories
{
	public record GetSkillCategoryQuery : IRequest<ApiResponse<List<SkillCategoryDto>>>;
}
