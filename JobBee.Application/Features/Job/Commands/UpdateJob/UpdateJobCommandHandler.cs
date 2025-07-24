using AutoMapper;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.ElasticSearchService;
using JobBee.Application.Exceptions;
using JobBee.Application.Features.Job.Queries.GetAllJobs;
using JobBee.Application.Models.Response;
using JobBee.Domain.Entities;
using MediatR;

namespace JobBee.Application.Features.Job.Commands.UpdateJob
{
	public class UpdateJobCommandHandler(
			IUnitOfWork<Domain.Entities.Job, Guid> unitOfWork,
			IUnitOfWork<Domain.Entities.Employer, Guid> employerRepository,
			IUnitOfWork<Domain.Entities.Subscription, Guid> subcriptionRepository,
			IElasticSearchService<JobDto> elasticSearchService,
			IMapper mapper
		)
		: IRequestHandler<UpdateJobCommand, ApiResponse<bool>>
	{
		public async Task<ApiResponse<bool>> Handle(UpdateJobCommand request, CancellationToken cancellationToken)
		{
			var jobDomain = unitOfWork.GenericRepository.GetById(request.JobId);
			if (jobDomain == null)
			{
				throw new NotFoundException(nameof(jobDomain), request);
			}
			var employerQuery = employerRepository.GenericRepository.GetQueryAble();
			var employer = employerQuery.FirstOrDefault(x => x.UserId == request.UserId);
			if (employer == null)
			{
				throw new NotFoundException(nameof(employer), request);
			}
			var isOwnerJob = jobDomain.EmployerId == employer.Id;
			if (!isOwnerJob)
			{
				throw new UnauthorizedAccessException("You does not have permission to acces to this job");
			}

			var subscriptionQuery = subcriptionRepository
				.GenericRepository
				.GetQueryAble();

			var subcriptions = subscriptionQuery
				.Where(x => x.UserId == request.UserId && x.Status == "active")
				.ToList();

			if (subcriptions.Count <= 0)
			{
				throw new BadRequestException("Active subscription not found for this user.");
			}

			var maxEndDate = subcriptions.Max(x => x.EndDate);

			var isExceedingEndDate = DateTimeOffset.FromUnixTimeSeconds(request.ApplicationDeadline).UtcDateTime > maxEndDate;

			if (isExceedingEndDate)
			{
				throw new BadRequestException("The application deadline exceeds the allowed subscription end date.");
			}

			jobDomain.Title = request.Title;
			jobDomain.Description = request.Description;
			jobDomain.JobTypeId = request.JobTypeId;
			jobDomain.ExperienceLevelId = request.ExperienceLevelId;
			jobDomain.MinEducationId = request.MinEducationId;
			jobDomain.JobCategoryId = request.JobCategoryId;
			jobDomain.Responsibilities = request.Responsibilities;
			jobDomain.Requirements = request.Requirements;
			jobDomain.MinSalary = request.MinSalary;
			jobDomain.MaxSalary = request.MaxSalary;
			jobDomain.SalaryPeriod = request.SalaryPeriod;
			jobDomain.Currency = request.Currency;
			jobDomain.IsSalaryNegotiable = request.IsSalaryNegotiable;
			jobDomain.LocationCity = request.LocationCity;
			jobDomain.LocationState = request.LocationState;
			jobDomain.LocationCountry = request.LocationCountry;
			jobDomain.IsRemote = request.IsRemote;
			jobDomain.AllowsWorkFromHome = request.AllowsWorkFromHome;
			jobDomain.ApplicationDeadline = request.ApplicationDeadline;
			jobDomain.IsFeatured = request.IsFeatured;
			jobDomain.UpdatedAt = DateTime.Now;

			unitOfWork.GenericRepository.Update(jobDomain);
			var affectedRows = await unitOfWork.SaveChangesAsync();

			if (affectedRows <= 0)
			{
				throw new Exception("Error occur when update in database");
			}

			var updatedJob = unitOfWork.GenericRepository.GetByIdIncluding(jobDomain.Id,
				j => j.Employer,
				j => j.JobCategory!,
				j => j.JobType!,
				j => j.ExperienceLevel!,
			j => j.MinEducation!
			);

			var updatedJobDto = mapper.Map<JobDto>(updatedJob);

			var isSuccessResponse = await elasticSearchService.AddOrUpdate(updatedJobDto);

			if (!isSuccessResponse)
			{
				throw new Exception("Error occur when update in els");
			}

			return new ApiResponse<bool>("Success", 200, true);
		}
	}
}
