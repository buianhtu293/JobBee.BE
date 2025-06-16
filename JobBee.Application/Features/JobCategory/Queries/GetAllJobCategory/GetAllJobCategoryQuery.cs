using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.JobCategory.Queries.GetAllJobCategory
{
	public record GetAllJobCategoryQuery : IRequest<ApiResponse<List<JobCategoryDto>>>;
}
