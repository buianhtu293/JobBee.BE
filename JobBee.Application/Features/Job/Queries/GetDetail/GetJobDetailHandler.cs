using JobBee.Application.ElasticSearchService;
using JobBee.Application.Exceptions;
using JobBee.Application.Features.Job.Queries.GetAllJobs;
using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.Job.Queries.GetDetail
{
	public class GetJobDetailHandler(
		IElasticSearchService<JobDto> elasticSearchService
	) : IRequestHandler<GetJobDetailQuery, ApiResponse<JobDto>>
	{
		public async Task<ApiResponse<JobDto>> Handle(GetJobDetailQuery request, CancellationToken cancellationToken)
		{
			var job = await elasticSearchService.Get(request.Id.ToString());
			if(job == null)
			{
				throw new NotFoundException(nameof(JobDto), request.Id);
			}

			var apiResponse = new ApiResponse<JobDto>("Success", 200, job);

			return apiResponse;
		}
	}
}
