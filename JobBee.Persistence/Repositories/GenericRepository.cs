using System.Linq.Expressions;
using JobBee.Application.Contracts.Persistence;
using JobBee.Persistence.DatabaseContext;
using JobBee.Shared.Paginators;
using Microsoft.EntityFrameworkCore;

namespace JobBee.Persistence.Repositories
{
	/// <summary>
	/// Serves as a generic base class for concrete repositories to support basic CRUD oprations on data in the system.
	/// </summary>
	/// <typeparam name="TEntity">The type of entity this repository works with. Must be a class inheriting DomainEntity</typeparam>
	/// <typeparam name="TPrimaryKey">The type of primary key</typeparam>
	public class GenericRepository<TEntity, TPrimaryKey> : IGenericRepository<TEntity, TPrimaryKey>, IDisposable where TEntity : class
	{
		protected readonly JobBeeContext _context;

		public GenericRepository(JobBeeContext context)
		{
			_context = context;
		}

		public int Count()
		{
			return GetAll().Count();
		}

		public int Count(Expression<Func<TEntity, bool>> predicate)
		{
			return GetAll().Count(predicate);
		}

		public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
		{
			return await GetAll().CountAsync(predicate);
		}

		public async Task<int> CountAsync()
		{
			return await GetAll().CountAsync();
		}

		public void Delete(TEntity entity)
		{
			_context.Set<TEntity>().Remove(entity);
		}

		public void Delete(TPrimaryKey id)
		{
			_context.Set<TEntity>().Remove(GetById(id));
		}

		public void Delete(Expression<Func<TEntity, bool>> predicate)
		{
			_context.Set<TEntity>().RemoveRange(GetAll().Where(predicate));
		}

		public TEntity? FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
		{
			return GetAll().FirstOrDefault(predicate);
		}

		//public TEntity? FirstOrDefault(TPrimaryKey id)
		//{
		//	return _context.Set<TEntity>().FirstOrDefault(x => x.Id.Equals(id));
		//}

		public async Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
		{
			return await GetAll().FirstOrDefaultAsync(predicate);
		}

		//public async Task<TEntity?> FirstOrDefaultAsync(TPrimaryKey id)
		//{
		//	return await GetAll().FirstOrDefaultAsync(x => x.Id.Equals(id));
		//}

		public TEntity? GetById(TPrimaryKey id)
		{
			return _context.Set<TEntity>().Find(id);
		}

		public IQueryable<TEntity> GetAll(bool isAll = true)
		{
			return _context.Set<TEntity>().AsQueryable();
		}

		public IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] propertySelectors)
		{
			IQueryable<TEntity> items = GetAll();

			if (propertySelectors != null)
			{
				foreach (var includeProperty in propertySelectors)
				{
					items = items.Include(includeProperty);
				}
			}
			return items;
		}

		public List<TEntity> GetAllList(Expression<Func<TEntity, bool>> predicate)
		{
			return GetAll().Where(predicate).ToList();
		}

		public List<TEntity> GetAllList()
		{
			return GetAll().ToList();
		}

		public async Task<List<TEntity>> GetAllListAsync(Expression<Func<TEntity, bool>> predicate)
		{
			return await GetAll().Where(predicate).ToListAsync();
		}

		public async Task<List<TEntity>> GetAllListAsync()
		{
			return await GetAll().ToListAsync();
		}

		public async Task<TEntity?> GetAsync(TPrimaryKey id)
		{
			return await _context.Set<TEntity>().FindAsync(id);
		}

		public TEntity Insert(TEntity entity)
		{
			return _context.Set<TEntity>().Add(entity).Entity;
		}

		//public TPrimaryKey InsertAndGetId(TEntity entity)
		//{
		//	var result = _context.Set<TEntity>().Add(entity);
		//	return result.Entity.Id;
		//}

		//public async Task<TPrimaryKey> InsertAndGetIdAsync(TEntity entity)
		//{
		//	var result = await _context.Set<TEntity>().AddAsync(entity);
		//	return result.Entity.Id;
		//}

		public async Task<TEntity> InsertAsync(TEntity entity)
		{
			var result = await _context.Set<TEntity>().AddAsync(entity);
			return result.Entity;
		}

		public long LongCount(Expression<Func<TEntity, bool>> predicate)
		{
			return GetAll().LongCount(predicate);
		}

		public long LongCount()
		{
			return GetAll().LongCount();
		}

		public async Task<long> LongCountAsync()
		{
			return await GetAll().LongCountAsync();
		}

		public async Task<long> LongCountAsync(Expression<Func<TEntity, bool>> predicate)
		{
			return await GetAll().LongCountAsync(predicate);
		}

		public TEntity Single(Expression<Func<TEntity, bool>> predicate)
		{
			return GetAll().Single(predicate);
		}

		public async Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate)
		{
			return await GetAll().SingleAsync(predicate);
		}

		public TEntity Update(TEntity entity)
		{
			var trackedEntity = _context.Set<TEntity>().Local
	.FirstOrDefault(e => _context.Entry(e).Property("Id").CurrentValue.Equals(
		_context.Entry(entity).Property("Id").CurrentValue));

			if (trackedEntity != null)
			{
				_context.Entry(trackedEntity).State = EntityState.Detached;
			}

			var result = _context.Set<TEntity>().Update(entity);
			return result.Entity;
		}

		public async Task<PageResult<TEntity>> GetPaginatedAsync(int pageIndex, int pageSize, Func<IQueryable<TEntity>, IQueryable<TEntity>>? filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null)
		{
			var query = _context.Set<TEntity>().AsQueryable();
			if (filter != null)
			{
				query = filter(query);
			}
			int totalItems = await query.CountAsync();
			if (orderBy != null)
			{
				query = orderBy(query);
			}
			else
			{
				// If no ordering specified, try to order by primary key
				var param = Expression.Parameter(typeof(TEntity), "e");
				var idProp = Expression.PropertyOrField(param, "Id");
				var lambda = Expression.Lambda<Func<TEntity, object>>(
					Expression.Convert(idProp, typeof(object)), param);
				query = query.OrderBy(lambda);
				//query = query.OrderBy(e => e.Id);
			}
			var items = await query
				.Skip((pageIndex - 1) * pageSize)
				.Take(pageSize)
				.ToListAsync();

			var pageResult = new PageResult<TEntity>(items, totalItems, pageIndex, pageSize);
			return pageResult;
		}

		public async Task<PageResult<TEntity>> GetPaginatedAsyncIncluding(
												int pageIndex,
												int pageSize,
												Func<IQueryable<TEntity>, IQueryable<TEntity>>? filter = null,
												Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
												params Expression<Func<TEntity, object>>[] includes)
		{
			var query = _context.Set<TEntity>().AsQueryable();

			// Apply includes
			if (includes != null && includes.Length > 0)
			{
				foreach (var include in includes)
				{
					query = query.Include(include);
				}
			}

			// Apply filter
			if (filter != null)
			{
				query = filter(query);
			}

			// Count total items after filtering
			int totalItems = await query.CountAsync();

			// Apply ordering
			if (orderBy != null)
			{
				query = orderBy(query);
			}
			else
			{
				// Fallback: order by Id (assumes entity has "Id" property)
				var param = Expression.Parameter(typeof(TEntity), "e");
				var idProp = Expression.PropertyOrField(param, "Id");
				var lambda = Expression.Lambda<Func<TEntity, object>>(
					Expression.Convert(idProp, typeof(object)), param);
				query = query.OrderBy(lambda);
			}

			// Apply pagination
			var items = await query
				.Skip((pageIndex - 1) * pageSize)
				.Take(pageSize)
				.ToListAsync();

			return new PageResult<TEntity>(items, totalItems, pageIndex, pageSize);
		}


		public async Task InsertRange(List<TEntity> entities)
		{
			await _context.Set<TEntity>().AddRangeAsync(entities);
		}

		public IQueryable<TEntity> GetQueryAble()
		{
			return _context.Set<TEntity>().AsQueryable();
		}

		private bool disposed = false;

		protected virtual void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (disposing)
				{
					_context.Dispose();
				}
				disposed = true;
			}
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate, bool isAll = true)
		{
			return GetAll(isAll).Where(predicate);
		}
	}
}
