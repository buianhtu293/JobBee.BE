using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Exceptions;
using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.Industry.Queries.GetIndustryDetail
{
	public class GetIndustryDetailHandler : IRequestHandler<GetIndustryDetailQuery, ApiResponse<IndustryDetailDto>>
	{
		private readonly IMapper _mapper;
		private readonly IIndustryRepository _industryRepository;

		public GetIndustryDetailHandler(IMapper mapper,
			IIndustryRepository industryRepository)
		{
			_mapper = mapper;
			_industryRepository = industryRepository;
		}

		public async Task<ApiResponse<IndustryDetailDto>> Handle(GetIndustryDetailQuery request, CancellationToken cancellationToken)
		{
			var industry = _industryRepository.GetById(request.id);

			if(industry == null)
			{
				throw new NotFoundException(nameof(industry), request.id);
			}

			var industryDetail = _mapper.Map<IndustryDetailDto>(industry);
			var data = new ApiResponse<IndustryDetailDto>("Success", 200, industryDetail);

			return data;
		}
	}
}
