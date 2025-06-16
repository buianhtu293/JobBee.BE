using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.JobCategory.Commands.UpdateJobCategory
{
	public class UpdateJobCategoryCommand : IRequest<ApiResponse<UpdateJobCategoryDto>>
	{
		public Guid Id { get; set; }
		public string CategoryName { get; set; } = null!;
		public Guid? ParentCategoryId { get; set; }
	}
}
