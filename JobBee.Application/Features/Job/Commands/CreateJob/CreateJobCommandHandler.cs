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
		IUnitOfWork<Domain.Entities.Subscription, Guid> subcriptionRepository,
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

			var subscriptionQuery = subcriptionRepository
				.GenericRepository
				.GetQueryAble();

			var subcriptions = subcriptionRepository.GenericRepository
				.GetAllIncluding(x => x.Plan)
				.Where(x => x.UserId == request.UserId && x.Status == "active")
				.ToList();

			if (subcriptions.Count <= 0)
			{
				throw new BadRequestException("Active subscription not found for this user.");
			}

			// miss case check number of post job in db
			//var numberOfPostJob = subcriptions.Sum(x => x.Plan.)

			var maxEndDate = subcriptions.Max(x => x.EndDate);

			var isExceedingEndDate = DateTimeOffset.FromUnixTimeSeconds(request.ApplicationDeadline).UtcDateTime > maxEndDate;

			if (isExceedingEndDate)
			{
				throw new BadRequestException("The application deadline exceeds the allowed subscription end date.");
			}

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
