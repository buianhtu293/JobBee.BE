using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.EducationLevel.Queries.GetAllEducationLevel
{
	public class EducationLevelQueryHandler : IRequestHandler<EducationLevelQuery, ApiResponse<List<EducationLevelDto>>>
	{
		private readonly IMapper _mapper;
		private readonly IEducationLevelRepository _educationLevel;

		public EducationLevelQueryHandler(IMapper mapper, IEducationLevelRepository educationLevel)
		{
			_mapper = mapper;
			_educationLevel = educationLevel;
		}

		public async Task<ApiResponse<List<EducationLevelDto>>> Handle(EducationLevelQuery request, CancellationToken cancellationToken)
		{
			var educationLevels = await _educationLevel.GetAllListAsync();

			var educationLevelLists = _mapper.Map<List<EducationLevelDto>>(educationLevels);
			var data = new ApiResponse<List<EducationLevelDto>>("Success", 200, educationLevelLists);

			return data;
		}
	}
}
