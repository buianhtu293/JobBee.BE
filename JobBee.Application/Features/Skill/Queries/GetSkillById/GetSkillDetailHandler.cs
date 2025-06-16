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

namespace JobBee.Application.Features.Skill.Queries.GetSkillById
{
	public class GetSkillDetailHandler : IRequestHandler<GetSkillDetailQuery, ApiResponse<SkillDetailDto>>
	{
		private readonly IMapper _mapper;
		private readonly ISkillRepository _skillRepository;

		public GetSkillDetailHandler(IMapper mapper, ISkillRepository skillRepository)
		{
			_mapper = mapper;
			_skillRepository = skillRepository;
		}
		public async Task<ApiResponse<SkillDetailDto>> Handle(GetSkillDetailQuery request, CancellationToken cancellationToken)
		{
			var skill = _skillRepository.GetById(request.id);

			if (skill == null)
			{
				throw new NotFoundException(nameof(skill), request.id);
			}

			var skillDetail = _mapper.Map<SkillDetailDto>(skill);
			var data = new ApiResponse<SkillDetailDto>("Success", 200, skillDetail);

			return data;

		}
	}
}
