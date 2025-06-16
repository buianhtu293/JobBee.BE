using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBee.Application.Features.JobCategory.Commands.UpdateJobCategory
{
	public class UpdateJobCategoryDto
	{
		public Guid Id { get; set; }
		public string CategoryName { get; set; } = null!;
		public Guid? ParentCategoryId { get; set; }
		public DateTime? CreatedAt { get; set; }
	}
}
