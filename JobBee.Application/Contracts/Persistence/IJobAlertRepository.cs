using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobBee.Domain.Entities;

namespace JobBee.Application.Contracts.Persistence
{
	public interface IJobAlertRepository : IGenericRepository<JobAlert, Guid>
	{
		Task<JobAlert> GetJobAlert(Guid candidateId, Guid jobId);
	}
}
