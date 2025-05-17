using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobBee.Application.Contracts.Persistence;
using JobBee.Domain.Common;
using JobBee.Persistence.DatabaseContext;

namespace JobBee.Persistence.Repositories
{
	public class UnitOfWork<TEntity, TPrimaryKey>(JobBeeDatabaseContext context) : IUnitOfWork<TEntity, TPrimaryKey> where TEntity : BaseEntity<TPrimaryKey>
	{
		private IGenericRepository<TEntity, TPrimaryKey>? _genericRepository;

		public IGenericRepository<TEntity, TPrimaryKey> GenericRepository
		{
			get
			{
				if (_genericRepository == null)
				{
					_genericRepository = new GenericRepository<TEntity, TPrimaryKey>(context);
				}
				return _genericRepository;
			}
		}

		public int Commit()
		{
			return context.SaveChanges();
		}

		public async Task<int> CommitAsync()
		{
			return await context.SaveChangesAsync();
		}
		public async Task<int> SaveChangesAsync()
		{
			return await context.SaveChangesAsync();
		}
	}
}
