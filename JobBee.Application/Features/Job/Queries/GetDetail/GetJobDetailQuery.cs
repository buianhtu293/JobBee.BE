using JobBee.Application.Features.Job.Queries.GetAllJobs;
using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.Job.Queries.GetDetail
{
	public class GetJobDetailQuery : IRequest<ApiResponse<JobDto>>
	{
		public Guid Id { get; set; }
	}
}
