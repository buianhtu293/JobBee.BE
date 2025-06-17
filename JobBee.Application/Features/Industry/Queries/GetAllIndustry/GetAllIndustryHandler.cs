using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Features.Skill.Queries.GetAllSkill;
using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.Industry.Queries.GetAllIndustry
{
	public class GetAllIndustryHandler : IRequestHandler<GetAllIndustryQuery, ApiResponse<List<IndustryDto>>>
	{
		private readonly IMapper _mapper;
		private readonly IIndustryRepository _industryRepository;

		public GetAllIndustryHandler(IMapper mapper, 
			IIndustryRepository industryRepository)
		{
			_mapper = mapper;
			_industryRepository = industryRepository;
		}

		public async Task<ApiResponse<List<IndustryDto>>> Handle(GetAllIndustryQuery request, CancellationToken cancellationToken)
		{
			var industries = await _industryRepository.GetAllListAsync();

			var industryList = _mapper.Map<List<IndustryDto>>(industries);
			var data = new ApiResponse<List<IndustryDto>>("Success", 200, industryList);

			return data;
		}
	}
}
