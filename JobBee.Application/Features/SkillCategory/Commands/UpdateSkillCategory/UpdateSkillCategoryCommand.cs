using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace JobBee.Application.Features.SkillCategory.Commands.UpdateSkillCategory
{
	public class UpdateSkillCategoryCommand : IRequest<Unit>
	{
		public Guid Id { get; set; }
		public string CategoryName { get; set; } = null!;
	}
}
