using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.CompanySize.Commands.CreateCompanySize
{
	public class CreateCompanySizeCommand : IRequest<ApiResponse<CreateCompanySizeDto>>
	{
		public string SizeRange { get; set; } = null!;
	}
}
