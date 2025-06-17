using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.Industry.Queries.GetIndustryDetail
{
	public record GetIndustryDetailQuery(Guid id) : IRequest<ApiResponse<IndustryDetailDto>>;
}
