using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.CompanySize.Commands.UpdateCompanySize
{
	public class UpdateCompanySizeCommand : IRequest<ApiResponse<UpdateCompanySizeDto>>
	{
		public Guid Id { get; set; }
		public string SizeRange { get; set; } = null!;
	}
}
