using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.Industry.Commands.UpdateIndustry
{
	public class UpdateIndustryCommand : IRequest<ApiResponse<UpdateIndustryDto>>
	{
		public string IndustryName { get; set; } = null!;
	}
}
