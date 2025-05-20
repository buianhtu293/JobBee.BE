using JobBee.Application.Contracts.Persistence;
using JobBee.Persistence.DatabaseContext;

namespace JobBee.Persistence.Repositories
{
	public class UnitOfWork<TEntity, TPrimaryKey>(JobBeeContext context) : IUnitOfWork<TEntity, TPrimaryKey> where TEntity : class
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
