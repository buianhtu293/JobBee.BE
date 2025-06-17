using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobBee.Application.Models.Response;
using JobBee.Shared.Paginators;
using MediatR;

namespace JobBee.Application.Features.Employer.Queries.GetAllEmployer
{
	public class EmployerPageResultQuery : IRequest<ApiResponse<PageResult<EmployerPageResultDto>>>
	{
		public int PageIndex { get; set; } = 1;
		public int PageSize { get; set; } = 10;
		public string? SearchName { get; set; }
	}
}
