using AutoMapper;
using JobBee.Application.Features.Candidate.Commands.CreateCandidate;
using JobBee.Application.Features.Candidate.Commands.UpdateCandidate;
using JobBee.Application.Features.Candidate.Queries.GetAllCandidate;
using JobBee.Application.Features.Candidate.Queries.GetCandidateDetail;
using JobBee.Domain.Entities;
using JobBee.Shared.Ultils;

namespace JobBee.Application.MappingProfiles
{
	public class CandidateProfile : Profile
	{
        public CandidateProfile()
        {
            CreateMap<CreateCandidateCommand, Candidate>().ForMember(des => des.BirthDate,
                otp => otp.MapFrom(src => src.BirthDate.ConvertToDate()));
            CreateMap<Candidate, CreateCandidateDto>();

            CreateMap<UpdateCandidateCommand, Candidate>().ForMember(des => des.BirthDate,
				otp => otp.MapFrom(src => src.BirthDate.ConvertToDate()));
            CreateMap<Candidate, UpdateCandidateDto>();

            CreateMap<Candidate, CandidateDto>().ReverseMap();

            CreateMap<Candidate, CandidateDetailDto>().ReverseMap();
		}
    }
}
