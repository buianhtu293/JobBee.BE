using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JobBee.Application.Features.CandidateEducation.Commands.AddCandidateEducation;
using JobBee.Application.Features.CandidateEducation.Commands.UpdateCandidateEducation;
using JobBee.Application.Features.CandidateEducation.Queries.GetAllCandidateEducation;
using JobBee.Application.Features.CandidateEducation.Queries.GetCandidateEducationByCandidateId;
using JobBee.Application.Features.CandidateEducation.Queries.GetCandidateEducationById;
using JobBee.Domain.Entities;

namespace JobBee.Application.MappingProfiles
{
	public class CandidateEducationProfile : Profile
	{
        public CandidateEducationProfile()
        {
            CreateMap<CandidateEducation, CreateCandidateEducationDto>().ReverseMap();
            CreateMap<CandidateEducation, CreateCandidateEducationCommand>().ReverseMap();

            CreateMap<CandidateEducation, UpdateCandidateEducationDto>().ReverseMap();
            CreateMap<CandidateEducation, UpdateCandidateEducationCommand>().ReverseMap();

            CreateMap<CandidateEducation, CandidateEducationDetailDto>().ReverseMap();

            CreateMap<CandidateEducation, CandidateEducationByCandidateIdDto>().ReverseMap();

            CreateMap<CandidateEducation, CandidateEducationDto>().ReverseMap();
        }
    }
}
