using AutoMapper;
using JobBee.Application.Features.CandidateEducation.Commands.AddCandidateEducation;
using JobBee.Application.Features.CandidateEducation.Commands.UpdateCandidateEducation;
using JobBee.Application.Features.CandidateEducation.Queries.GetAllCandidateEducation;
using JobBee.Application.Features.CandidateEducation.Queries.GetCandidateEducationByCandidateId;
using JobBee.Application.Features.CandidateEducation.Queries.GetCandidateEducationById;
using JobBee.Domain.Entities;
using JobBee.Shared.Ultils;

namespace JobBee.Application.MappingProfiles
{
	public class CandidateEducationProfile : Profile
	{
        public CandidateEducationProfile()
        {
            CreateMap<CandidateEducation, CreateCandidateEducationDto>().ReverseMap();
            CreateMap<CreateCandidateEducationCommand, CandidateEducation>().ForMember(des => des.StartDate,
                otp => otp.MapFrom(src => src.StartDate.ConvertToDate()))
                .ForMember(des => des.EndDate, otp => otp.MapFrom(src => src.EndDate.ConvertToDate()));


			CreateMap<CandidateEducation, UpdateCandidateEducationDto>().ReverseMap();
            CreateMap<CandidateEducation, UpdateCandidateEducationCommand>().ReverseMap();

            CreateMap<CandidateEducation, CandidateEducationDetailDto>().ReverseMap();

            CreateMap<CandidateEducation, CandidateEducationByCandidateIdDto>().ReverseMap();

            CreateMap<CandidateEducation, CandidateEducationDto>().ReverseMap();
        }
    }
}
