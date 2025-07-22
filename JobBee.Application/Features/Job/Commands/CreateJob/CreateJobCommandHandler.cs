using AutoMapper;
using JobBee.Application.Contracts.Logging;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.ElasticSearchService;
using JobBee.Application.Exceptions;
using JobBee.Application.Features.Job.Queries.GetAllJobs;
using JobBee.Application.Models.Response;
using JobBee.Domain.Entities;
using MediatR;

namespace JobBee.Application.Features.Job.Commands.CreateJob
{
	public class CreateJobCommandHandler(
		IMapper mapper,
		IUnitOfWork<Domain.Entities.Job, Guid> unitOfWork,
		IEmployerRepository employerRepository,
		IElasticSearchService<JobDto> elasticSearchService,
		IAppLogger<CreateJobCommandHandler> logger)
		: IRequestHandler<CreateJobCommand, bool>
	{

		public async Task<bool> Handle(CreateJobCommand request, CancellationToken cancellationToken)
		{
			var query = employerRepository.GetQueryAble();
			var employer = query.FirstOrDefault(e => e.UserId == request.UserId);
			var job = mapper.Map<Domain.Entities.Job>(request, opt =>
			{
				opt.Items["EmployerId"] = employer!.Id;
			});

			job.UpdatedAt = DateTime.Now;
			job.PostedAt = DateTime.Now;
			job.Id = Guid.NewGuid();
			unitOfWork.GenericRepository.Insert(job);
			var numberOfRecord = await unitOfWork.SaveChangesAsync();
			if (numberOfRecord < 0)
			{
				logger.LogWarning("Can not create new job to database");
				throw new BadRequestException("Invalid request");
			}

			// insert job to open search
			var insertedJob = unitOfWork.GenericRepository.GetByIdIncluding(job.Id, 
				j => j.Employer,
				j => j.JobCategory!,
				j => j.JobType!,
				j => j.ExperienceLevel!,
				j => j.MinEducation!
			);

			var insertedJobDto = mapper.Map<JobDto>(insertedJob);

			var isSuccessResponse = await elasticSearchService.AddOrUpdate(insertedJobDto);

			return isSuccessResponse;
		}
	}
}
