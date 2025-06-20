using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JobBee.Application.Features.SavedCandidate.Commands.CreateSavedCandidate;
using JobBee.Application.Features.SavedCandidate.Queries.GetSavedCandidateByEmployer;
using JobBee.Domain.Entities;

namespace JobBee.Application.MappingProfiles
{
	internal class SavedCandidateProfile : Profile
	{
        public SavedCandidateProfile()
        {
            CreateMap<SavedCandidate, CreateSavedCandidateCommand>().ReverseMap();
            CreateMap<SavedCandidate, CreateSavedCandidateDto>().ReverseMap();

            CreateMap<Candidate, SavedCandidateDto>()
				.ForMember(dest => dest.UserName, otp => otp.MapFrom(src => src.User.UserName));
		}
    }
}
