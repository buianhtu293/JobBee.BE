using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobBee.Domain.Entities;

namespace JobBee.Application.Contracts.Persistence
{
	public interface IEducationLevelRepository : IGenericRepository<EducationLevel, Guid>
	{
		Task<bool> IsEducationLevelUnique(string EducationLevelName);
		Task<EducationLevel?> GetByName(string EducationLevelName);
	}
}
