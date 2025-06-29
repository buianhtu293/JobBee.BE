using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Exceptions;
using JobBee.Application.Features.Job.Queries.GetAllJobs;
using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.Job.Queries.GetDetail
{
	public class GetJobDetailHandler(
		IJobRepository jobRepository
	) : IRequestHandler<GetJobDetailQuery, ApiResponse<JobDetailDto>>
	{
		public async Task<ApiResponse<JobDetailDto>> Handle(GetJobDetailQuery request, CancellationToken cancellationToken)
		{
			var job = await jobRepository.GetJobDetail(request.Id, cancellationToken);

			var apiResponse = new ApiResponse<JobDetailDto>("Success", 200, job);

			return apiResponse;
		}
	}
}
