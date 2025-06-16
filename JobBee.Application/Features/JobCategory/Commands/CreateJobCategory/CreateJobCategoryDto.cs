using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBee.Application.Features.JobCategory.Commands.CreateJobCategory
{
	public class CreateJobCategoryDto
	{
		public Guid Id { get; set; }
		public string CategoryName { get; set; } = null!;
		public Guid? ParentCategoryId { get; set; }
		public DateTime? CreatedAt { get; set; }
	}
}
