using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Exceptions;
using JobBee.Application.Features.Employer.Commands.CreateEmployer;
using JobBee.Application.Features.Job.Queries.GetDetail;
using JobBee.Domain.Entities;
using JobBee.Persistence.DatabaseContext;
using JobBee.Shared.Paginators;
using Microsoft.EntityFrameworkCore;

namespace JobBee.Persistence.Repositories
{
	public class JobRepository : GenericRepository<Job, Guid>, IJobRepository
	{
		public JobRepository(JobBeeContext context) : base(context)
		{
		}

		public async Task<PageResult<Job>> GetJobAlertByCandidateAsync(Guid candidateId, int pageIndex, int pageSize, CancellationToken cancellationToken)
		{
			Func<IQueryable<Domain.Entities.Job>, IQueryable<Domain.Entities.Job>>? filter = null;
			filter = query => query.Where(j => j.JobAlerts.Any(ja => ja.CandidateId == candidateId));

			Func<IQueryable<Domain.Entities.Job>, IOrderedQueryable<Domain.Entities.Job>>? orderBy = null;

			return await GetPaginatedAsyncIncluding(
				pageIndex,
				pageSize,
				filter,
				orderBy,
				j => j.JobAlerts,
				j => j.SavedJobs,
				j => j.JobApplications,
				e => e.Employer,
				c => c.JobCategory,
				t => t.JobType,
				e => e.ExperienceLevel,
				e => e.MinEducation
				);
		}

		public async Task<JobDetailDto> GetJobDetail(Guid jobId, CancellationToken cancellationToken)
		{
			var job = await _context.jobs
				.Include(j => j.Employer)
					.ThenInclude(e => e.EmployerSocialMedia)
				.Include(j => j.Employer)
					.ThenInclude(e => e.Industry)
				.Include(j => j.Employer)
					.ThenInclude(e => e.CompanySize)
				.Include(j => j.JobType)
				.Include(j => j.ExperienceLevel)
				.Include(j => j.MinEducation)
				.FirstOrDefaultAsync(x => x.Id == jobId);

			if(job == null) throw new NotFoundException(nameof(job), jobId);

			var jobDetailDto = new JobDetailDto
			{
				Title = job.Title,
				Description = job.Description,
				Responsibility = job.Responsibilities!,
				PostedAt = job.PostedAt!.Value,
				ApplicationDeadline = job.ApplicationDeadline!.Value,
				Level = job.MinEducation!.LevelName,
				MinSalary = job.MinSalary!.Value,
				MaxSalary = job.MaxSalary!.Value,
				LocationCity = job.LocationCity!,
				JobType = job.JobType!.TypeName,
				Experience = job.ExperienceLevel!.LevelName,
				Employer = new Application.Features.Employer.Queries.GetEmployerDetail.EmployerDetailDTO()
				{
					EmployerId = job.Employer.Id,
					CompanyLogo = job.Employer.CompanyLogo!,
					CompanyName = job.Employer.CompanyName,
					CompanySize = job.Employer.CompanySize!.SizeRange,
					ContactEmail = job.Employer.ContactEmail!,
					ContactPhone = job.Employer.ContactPhone!,
					Industry = job.Employer.Industry!.IndustryName,
					WebsiteUrl = job.Employer.WebsiteUrl!,
					SocialMedials = new List<SocialMedial>()
				}
			};

			foreach(var link in job.Employer.EmployerSocialMedia)
			{
				jobDetailDto.Employer.SocialMedials.Add(new SocialMedial
				{
					Link = link.ProfileUrl,
					Platform = link.PlatformName,
				});
			}

			return jobDetailDto;
		}

		public async Task<PageResult<Job>> GetJobsAppliedByCandidateAsync(Guid candidateId, int pageIndex, int pageSize, CancellationToken cancellationToken)
		{
			Func<IQueryable<Domain.Entities.Job>, IQueryable<Domain.Entities.Job>>? filter = null;
			filter = query => query.Where(j => j.JobApplications.Any(ja => ja.CandidateId == candidateId));

			Func<IQueryable<Domain.Entities.Job>, IOrderedQueryable<Domain.Entities.Job>>? orderBy = null;

			return await GetPaginatedAsyncIncluding(
				pageIndex,
				pageSize,
				filter,
				orderBy,
				j => j.JobApplications,
				e => e.Employer,
				c => c.JobCategory,
				t => t.JobType,
				e => e.ExperienceLevel,
				e => e.MinEducation
				);
		}

		public async Task<PageResult<Job>> GetSavedJobByCandidateAsync(Guid candidateId, int pageIndex, int pageSize, CancellationToken cancellationToken)
		{
			Func<IQueryable<Domain.Entities.Job>, IQueryable<Domain.Entities.Job>>? filter = null;
			filter = query => query.Where(j => j.SavedJobs.Any(ja => ja.CandidateId == candidateId));

			Func<IQueryable<Domain.Entities.Job>, IOrderedQueryable<Domain.Entities.Job>>? orderBy = null;

			return await GetPaginatedAsyncIncluding(
				pageIndex,
				pageSize,
				filter,
				orderBy,
				j => j.SavedJobs,
				j => j.JobApplications,
				e => e.Employer,
				c => c.JobCategory,
				t => t.JobType,
				e => e.ExperienceLevel,
				e => e.MinEducation
				);
		}
	}
}
