using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.Runtime.Internal;
using JobBee.Application.Features.Candidate.Queries.GetAllCandidate;
using JobBee.Application.Models.Response;
using JobBee.Shared.Paginators;
using MediatR;

namespace JobBee.Application.Features.Candidate.Queries.GetCandidatePageResult
{
	public class CandidatePageResultQuery : IRequest<ApiResponse<PageResult<CandidateDto>>>
	{
		public int PageIndex { get; set; } = 1;
		public int PageSize { get; set; } = 10;
		public string? SearchName { get; set; }
		public string? Phone { get; set; }
		public string? Gender { get; set; }
		public string? Address { get; set; }
		public string? City { get; set; }
		public string? State { get; set; }
		public string? Country { get; set; }
		public string? PostalCode { get; set; }
		public decimal? CurrentSalary { get; set; }
		public decimal? SalaryExpectation { get; set; }
		public int? ExperienceYears { get; set; }
		public bool? IsAvailableForHire { get; set; }
		public bool IsAscCreateAt { get; set; }
	}
}
