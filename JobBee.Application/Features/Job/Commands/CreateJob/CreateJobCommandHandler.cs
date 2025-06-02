using AutoMapper;
using JobBee.Application.Contracts.Logging;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.ElasticSearchService;
using JobBee.Application.Exceptions;
using JobBee.Application.Models.Response;
using JobBee.Domain.Entities;
using MediatR;

namespace JobBee.Application.Features.Job.Commands.CreateJob
{
	public class CreateJobCommandHandler(
		IMapper mapper,
		IUnitOfWork<Domain.Entities.Job, Guid> unitOfWork,
		IElasticSearchService<Domain.Entities.Job> elasticSearchService,
		IAppLogger<CreateJobCommandHandler> logger)
		: IRequestHandler<CreateJobCommand, bool>
	{

		public async Task<bool> Handle(CreateJobCommand request, CancellationToken cancellationToken)
		{
			var job = mapper.Map<Domain.Entities.Job>(request);
			unitOfWork.GenericRepository.Insert(job);
			var numberOfRecord = await unitOfWork.SaveChangesAsync();
			if (numberOfRecord < 0)
			{
				logger.LogWarning("Can not create new job to database");
				throw new BadRequestException("Invalid request");
			}
			// not prefer
			var isValid = await elasticSearchService.AddOrUpdate(job);
			if (!isValid)
			{
				logger.LogWarning("Can not create new job to elastic search");
				throw new BadRequestException("Invalid request");
			}
			return isValid;
		}
	}
}
