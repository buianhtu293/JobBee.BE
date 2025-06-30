using AutoMapper;
using JobBee.Application.Features.SubcriptionPlan.Commands.CreateSubscriptionPlan;
using JobBee.Application.Features.SubcriptionPlan.Commands.UpdateSubscriptionPlan;
using JobBee.Application.Features.SubcriptionPlan.Queries.GetAllSubscriptionPlan;
using JobBee.Application.Features.SubcriptionPlan.Queries.GetSubscriptionPlanDetail;
using JobBee.Domain.Entities;

namespace JobBee.Application.MappingProfiles
{
	public class SubscriptionPlanProfile : Profile
	{
        public SubscriptionPlanProfile()
        {
            CreateMap<SubscriptionPlan, CreateSubscriptionPlanCommand>().ReverseMap();
            CreateMap<SubscriptionPlan, CreateSubscriptionPlanDto>().ReverseMap();

            CreateMap<SubscriptionPlan, UpdateSubscriptionPlanCommand>().ReverseMap();
            CreateMap<SubscriptionPlan, UpdateSubscriptionPlanDto>().ReverseMap();

            CreateMap<SubscriptionPlan, SubscriptionPlanDto>().ReverseMap();

            CreateMap<SubscriptionPlan, SubscriptionPlanDetailDto>().ReverseMap();

        }
    }
}
