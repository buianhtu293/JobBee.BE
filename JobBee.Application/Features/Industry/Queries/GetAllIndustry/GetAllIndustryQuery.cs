using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.Industry.Queries.GetAllIndustry
{
	public record GetAllIndustryQuery : IRequest<ApiResponse<List<IndustryDto>>>;
}
