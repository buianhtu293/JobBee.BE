using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.ExperienceLevel.Queries.GetAllExperienceLevel
{
	public class GetAllExperienceLevelHandler : IRequestHandler<GetAllExperienceLevelQuery, ApiResponse<List<ExperienceLevelDto>>>
	{
		private readonly IMapper _mapper;
		private readonly IExperienceLevelRepository _experienceLevelRepository;

		public GetAllExperienceLevelHandler(IMapper mapper, 
			IExperienceLevelRepository experienceLevelRepository)
		{
			_mapper = mapper;
			_experienceLevelRepository = experienceLevelRepository;
		}

		public async Task<ApiResponse<List<ExperienceLevelDto>>> Handle(GetAllExperienceLevelQuery request, CancellationToken cancellationToken)
		{
			var experienceLevels = await _experienceLevelRepository.GetAllListAsync();

			var experienceLevelList = _mapper.Map<List<ExperienceLevelDto>>(experienceLevels);
			var data = new ApiResponse<List<ExperienceLevelDto>>("Success", 200, experienceLevelList);

			return data;
		}
	}
}
