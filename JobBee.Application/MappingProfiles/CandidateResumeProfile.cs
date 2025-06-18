using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JobBee.Application.Features.CandidateResume.Queries.GetAllCandidateResume;
using JobBee.Application.Features.CandidateResume.Queries.GetCandidateResumeDetail;
using JobBee.Domain.Entities;

namespace JobBee.Application.MappingProfiles
{
	public class CandidateResumeProfile : Profile
	{
        public CandidateResumeProfile()
        {
            CreateMap<CandidateResume, CandidateResumeDto>().ReverseMap();

            CreateMap<CandidateResume, CandidateResumeDetailDto>().ReverseMap();
        }
    }
}
