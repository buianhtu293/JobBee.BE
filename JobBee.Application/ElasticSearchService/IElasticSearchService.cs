using JobBee.Shared.Paginators;
using OpenSearch.Client;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace JobBee.Application.ElasticSearchService
{
	public interface IElasticSearchService<TModel> where TModel : class
	{
		/// <summary>
		/// Create a index in OpenSearch if not existed
		/// </summary>
		/// <param name="indexName">Name of index</param>
		/// <returns></returns>
		Task CreateIndexIfNotExistesAsync(string indexName);

		/// <summary>
		/// Add or update a model
		/// </summary>
		/// <param name="model">Pass a model</param>
		/// <returns>true if created/updated successfully</returns>
		Task<bool> AddOrUpdate(TModel model);

		/// <summary>
		/// Bulk add or update models
		/// </summary>
		Task<bool> AddOrUpdateBulk(IEnumerable<TModel> models, string indexName);

		/// <summary>
		/// Get specific model by key
		/// </summary>
		Task<TModel?> Get(string key, string? index = null);

		/// <summary>
		/// Get a list of models with pagination and sorting
		/// </summary>
		Task<PageResult<TModel>> GetList<TProperty>(
			Func<SearchDescriptor<TModel>, ISearchRequest>? searchConfig = null,
			Expression<Func<TModel, TProperty>>? orderBy = null,
			bool? ascending = true,
			int? page = 0,
			int? pageSize = 20,
			string? index = null);

		/// <summary>
		/// Remove a model by key
		/// </summary>
		Task<bool> Remove(string key, string? index = null);

		/// <summary>
		/// Remove all models in index
		/// </summary>
		Task<long?> RemoveAll(string? index = null);
	}
}
