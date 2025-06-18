using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobBee.Domain.Entities;
using JobBee.Shared.Paginators;

namespace JobBee.Application.Contracts.Persistence
{
	public interface IJobApplicationRepository : IGenericRepository<JobApplication, Guid>
	{
		Task<List<JobApplication>> GetJobApplicationByCandidateId(Guid candidateId);
		Task<List<JobApplication>> GetJobApplicationByJobId(Guid jobId);
	}
}
