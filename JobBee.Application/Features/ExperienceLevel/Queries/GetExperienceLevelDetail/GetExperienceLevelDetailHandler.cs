using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Exceptions;
using JobBee.Application.Models.Response;
using JobBee.Domain.Entities;
using MediatR;

namespace JobBee.Application.Features.ExperienceLevel.Queries.GetExperienceLevelDetail
{
	public class GetExperienceLevelDetailHandler : IRequestHandler<GetExperienceLevelDetailQuery, ApiResponse<ExperienceLevelDetailDto>>
	{
		private readonly IMapper _mapper;
		private readonly IExperienceLevelRepository _experienceLevelRepository;

		public GetExperienceLevelDetailHandler(IMapper mapper,
			IExperienceLevelRepository experienceLevelRepository)
		{
			_mapper = mapper;
			_experienceLevelRepository = experienceLevelRepository;
		}

		public async Task<ApiResponse<ExperienceLevelDetailDto>> Handle(GetExperienceLevelDetailQuery request, CancellationToken cancellationToken)
		{
			var experienceLevel = _experienceLevelRepository.GetById(request.id);

			if (experienceLevel == null)
			{
				throw new NotFoundException(nameof(experienceLevel), request.id);
			}

			var experienceLevelDetail = _mapper.Map<ExperienceLevelDetailDto>(experienceLevel);
			var data = new ApiResponse<ExperienceLevelDetailDto>("Success", 200, experienceLevelDetail);

			return data;

		}
	}
}
