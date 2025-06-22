using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using JobBee.Domain.Entities;

namespace JobBee.Application.Contracts.Persistence
{
	public interface ICandidateEducationRepository : IGenericRepository<CandidateEducation, Guid>
	{
		Task<List<CandidateEducation>> GetCandidateEducationByCandidateId(Guid CandidateId);

		Task<List<CandidateEducation>> GetCandidateEducationByCandidateIdIncluding(
		Guid candidateId,
		params Expression<Func<CandidateEducation, object>>[] propertySelectors);
	}
}
