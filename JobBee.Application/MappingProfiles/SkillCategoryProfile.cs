using AutoMapper;
using JobBee.Application.Features.SkillCategory.Commands.CreateSkillCategory;
using JobBee.Application.Features.SkillCategory.Commands.UpdateSkillCategory;
using JobBee.Application.Features.SkillCategory.Queries.GetAllSkillCategories;
using JobBee.Application.Features.SkillCategory.Queries.GetSkillCategoryDetails;
using JobBee.Domain.Entities;

namespace JobBee.Application.MappingProfiles
{
	public class SkillCategoryProfile : Profile
	{
		public SkillCategoryProfile() 
		{
			CreateMap<SkillCategoryDto, SkillCategory>().ReverseMap();
			CreateMap<SkillCategoryDetailDto, SkillCategory>().ReverseMap();
			CreateMap<CreateSkillCategoryCommand, SkillCategory>().ReverseMap();
			CreateMap<CreateSkillCategoryCommand, SkillCategoryDto>().ReverseMap();
			CreateMap<UpdateSkillCategoryCommand, SkillCategory>().ReverseMap();
		}
	}
}
