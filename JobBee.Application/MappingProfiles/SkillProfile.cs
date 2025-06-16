using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JobBee.Application.Features.Skill.Commands.AddSkill;
using JobBee.Application.Features.Skill.Commands.UpdateSkill;
using JobBee.Application.Features.Skill.Queries.GetAllSkill;
using JobBee.Application.Features.Skill.Queries.GetSkillById;
using JobBee.Domain.Entities;

namespace JobBee.Application.MappingProfiles
{
	public class SkillProfile : Profile
	{
		public SkillProfile() 
		{ 
			CreateMap<Skill, CreateSkillCommand>().ReverseMap();
			CreateMap<Skill, CreateSkillDto>().ReverseMap();

			CreateMap<Skill, UpdateSkillDto>().ReverseMap();
			CreateMap<Skill, UpdateSkillCommand>().ReverseMap();

			CreateMap<Skill, SkillDto>().ReverseMap();

			CreateMap<Skill, SkillDetailDto>().ReverseMap();
		}
	}
}
