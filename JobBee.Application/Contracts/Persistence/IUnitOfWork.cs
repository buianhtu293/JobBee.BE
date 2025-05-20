namespace JobBee.Application.Contracts.Persistence
{
	public interface IUnitOfWork<TEntity, TPrimaryKey> where TEntity : class
	{
		public IGenericRepository<TEntity, TPrimaryKey> GenericRepository { get; }
		public Task<int> CommitAsync();
		public int Commit();
		public Task<int> SaveChangesAsync();
	}
}
