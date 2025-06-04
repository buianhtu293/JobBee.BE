using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobBee.Application.Features.SkillCategory.Queries.GetAllSkillCategories;
using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.SkillCategory.Commands.UpdateSkillCategory
{
	public class UpdateSkillCategoryCommand : IRequest<ApiResponse<SkillCategoryDto>>
	{
		public Guid Id { get; set; }
		public string CategoryName { get; set; } = null!;
	}
}
