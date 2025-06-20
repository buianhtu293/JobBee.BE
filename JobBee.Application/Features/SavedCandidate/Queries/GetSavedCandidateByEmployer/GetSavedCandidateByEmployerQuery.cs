using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobBee.Application.Models.Response;
using JobBee.Shared.Paginators;
using MediatR;

namespace JobBee.Application.Features.SavedCandidate.Queries.GetSavedCandidateByEmployer
{
	public class GetSavedCandidateByEmployerQuery : IRequest<ApiResponse<PageResult<SavedCandidateDto>>>
	{
		public Guid EmployerId { get; set; }
		public int PageIndex { get; set; } = 1;
		public int PageSize { get; set; } = 10;
	}
}
