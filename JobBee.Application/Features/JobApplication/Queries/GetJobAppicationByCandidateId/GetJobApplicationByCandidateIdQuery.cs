using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobBee.Application.Features.Job.Queries.GetAllJobs;
using JobBee.Application.Models.Response;
using JobBee.Shared.Paginators;
using MediatR;

namespace JobBee.Application.Features.JobApplication.Queries.GetJobAppicationByCandidateId
{
	public class GetJobApplicationByCandidateIdQuery : IRequest<ApiResponse<PageResult<JobAppliedDto>>>
	{
		public Guid CandidateId { get; set; }
		public int PageIndex { get; set; } = 1;
		public int PageSize { get; set; } = 10;
		
	}
}
