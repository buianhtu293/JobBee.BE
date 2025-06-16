using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.Skill.Queries.GetAllSkill
{
	public class GetAllSkillHandler : IRequestHandler<GetAllSkillQuery, ApiResponse<List<SkillDto>>>
	{
		private readonly IMapper _mapper;
		private readonly ISkillRepository _skillRepository;

		public GetAllSkillHandler(IMapper mapper, ISkillRepository skillRepository)
		{
			_mapper = mapper;
			_skillRepository = skillRepository;
		}

		public async Task<ApiResponse<List<SkillDto>>> Handle(GetAllSkillQuery request, CancellationToken cancellationToken)
		{
			var skills = await _skillRepository.GetAllListAsync();

			var skillList = _mapper.Map<List<SkillDto>>(skills);
			var data = new ApiResponse<List<SkillDto>>("Success", 200, skillList);

			return data;
		}
	}
}
