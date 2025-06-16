using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBee.Application.Features.JobCategory.Queries.GetJobCategoryDetail
{
	public class JobCategoryDetailDto
	{
		public Guid Id { get; set; }
		public string CategoryName { get; set; } = null!;
		public Guid? ParentCategoryId { get; set; }
		public DateTime? CreatedAt { get; set; }
	}
}
