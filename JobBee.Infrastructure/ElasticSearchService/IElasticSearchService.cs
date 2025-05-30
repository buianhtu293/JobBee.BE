using JobBee.Shared.Paginators;

namespace JobBee.Application.Services.ElasticSearchService
{
	public interface IElasticSearchService<TModel> where TModel : class
	{
		/// <summary>
		/// Create a index in elastic search if not existed
		/// </summary>
		/// <param name="indexName">name of index</param>
		/// <returns></returns>
		Task CreateIndexIfNotExistesAsync(string indexName);

		/// <summary>
		/// Add or update a model
		/// </summary>
		/// <param name="model">Pass a model</param>
		/// <returns>true if create successfully</returns>
		Task<bool> AddOrUpdate(TModel model);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="indexName"></param>
		/// <returns>true if create successfully</returns>
		Task<bool> AddOrUpdateBulk(IEnumerable<TModel> models, string indexName);

		/// <summary>
		/// Get specific model with a key 
		/// </summary>
		/// <param name="key">key of model</param>
		/// <returns>model</returns>
		Task<TModel?> Get(string key);

		/// <summary>
		/// Get list with paging
		/// </summary>
		/// <param name="page">number of page</param>
		/// <param name="pageSize">number of records in a page</param>
		/// <returns>page result</returns>
		Task<PageResult<TModel>> GetPagination(int page, int pageSize);

		/// <summary>
		/// Remove a model with a specific key 
		/// </summary>
		/// <param name="key">Key of model</param>
		/// <returns>true if remove successfully</returns>
		Task<bool> Remove(string key);

		/// <summary>
		/// Remove all model
		/// </summary>
		/// <returns>Number of records which were removed</returns>
		Task<long?> RemoveAll();
	}
}
