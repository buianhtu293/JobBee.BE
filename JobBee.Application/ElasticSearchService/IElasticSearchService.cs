using Elastic.Clients.Elasticsearch;
using JobBee.Shared.Paginators;
using Nest;
using System.Linq.Expressions;

namespace JobBee.Application.ElasticSearchService
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
		/// 
		/// </summary>
		/// <typeparam name="TProperty"></typeparam>
		/// <param name="searchConfig"></param>
		/// <param name="orderBy"></param>
		/// <param name="ascending"></param>
		/// <param name="page"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		Task<PageResult<TModel>> GetList<TProperty>(
			Func<SearchRequestDescriptor<TModel>, SearchRequestDescriptor<TModel>>? searchConfig = null,
			Expression<Func<TModel, TProperty>>? orderBy = null,
			bool? ascending = true,
			int? page = 1,
			int? pageSize = 20);

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
