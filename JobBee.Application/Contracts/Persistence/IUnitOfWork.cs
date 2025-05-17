using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobBee.Domain.Common;

namespace JobBee.Application.Contracts.Persistence
{
	public interface IUnitOfWork<TEntity, TPrimaryKey> where TEntity : BaseEntity<TPrimaryKey>
	{
		public IGenericRepository<TEntity, TPrimaryKey> GenericRepository { get; }
		public Task<int> CommitAsync();
		public int Commit();
		public Task<int> SaveChangesAsync();
	}
}
