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

namespace JobBee.Application.Features.EducationLevel.Queries.GetEducationLevelDetail
{
	public class EducationLevelDetailQueryHandler : IRequestHandler<EducationLevelDetailQuery, ApiResponse<EducationLevelDetailDto>>
	{
		private readonly IMapper _mapper;
		private readonly IEducationLevelRepository _educationLevel;

		public EducationLevelDetailQueryHandler(IMapper mapper, IEducationLevelRepository educationLevel)
		{
			_mapper = mapper;
			_educationLevel = educationLevel;
		}

		public async Task<ApiResponse<EducationLevelDetailDto>> Handle(EducationLevelDetailQuery request, CancellationToken cancellationToken)
		{
			var educationLevel = _educationLevel.GetById(request.id);

			if (educationLevel == null)
			{
				throw new NotFoundException(nameof(educationLevel), request.id);
			}

			var educationLevelDetail = _mapper.Map<EducationLevelDetailDto>(educationLevel);
			var data = new ApiResponse<EducationLevelDetailDto>("Success", 200, educationLevelDetail);

			return data;
		}
	}
}
