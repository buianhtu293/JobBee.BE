using Elastic.Clients.Elasticsearch;
using Elastic.Transport;
using JobBee.Domain.Config;
using JobBee.Shared.Paginators;
using Microsoft.Extensions.Options;

namespace JobBee.Application.Services
{
	public class ElasticSearchService<TModel> : IElasticSearchService<TModel> where TModel : class
	{

		private readonly ElasticsearchClient _elasticsearchClient;
		private readonly ElasticSearchSettings _elasticsearchSettings;

		public ElasticSearchService(IOptions<ElasticSearchSettings> optionsMonitor)
		{
			_elasticsearchSettings = optionsMonitor.Value;

			var settings = new ElasticsearchClientSettings(new Uri(_elasticsearchSettings.Url))
				.Authentication(new BasicAuthentication(_elasticsearchSettings.Username, _elasticsearchSettings.Password))
				.DefaultIndex(_elasticsearchSettings.DefaultIndex);

			_elasticsearchClient = new ElasticsearchClient(settings);
		}

		public async Task<bool> AddOrUpdate(TModel model)
		{
			var response = await _elasticsearchClient.IndexAsync(model, idx => idx.Index(_elasticsearchSettings.DefaultIndex).OpType(OpType.Index)
			);

			return response.IsValidResponse;
		}

		public async Task<bool> AddOrUpdateBulk(IEnumerable<TModel> models, string indexName)
		{
			var response = await _elasticsearchClient.BulkAsync(
				b => b.Index(_elasticsearchSettings.DefaultIndex)
					.UpdateMany(models, (ud, u) => ud.Doc(u).DocAsUpsert(true))
			);
			return response.IsValidResponse;
		}

		public async Task CreateIndexIfNotExistesAsync(string indexName)
		{
			// check index has been existed
			if (!_elasticsearchClient.Indices.Exists(indexName).Exists)
			{
				await _elasticsearchClient.CreateAsync(indexName);
			}
		}

		public async Task<TModel?> Get(string key)
		{
			var response = await _elasticsearchClient.GetAsync<TModel>(key, g => g.Index(_elasticsearchSettings.DefaultIndex));

			return response.Source;
		}

		public async Task<PageResult<TModel>> GetPagination(int page, int pageSize)
		{
			// Ensure valid page and pageSize values
			page = Math.Max(1, page); // Ensure page is at least 1
			pageSize = Math.Max(1, Math.Min(pageSize, 50)); // Enforce pageSize limits (1-50)

			// Calculate the 'from' parameter for Elasticsearch (zero-based)
			int from = (page - 1) * pageSize;

			// Perform the search query with pagination
			var response = await _elasticsearchClient.SearchAsync<TModel>(s => s
				.Indices(_elasticsearchSettings.DefaultIndex)
				.From(from)
				.Size(pageSize)
			);

			// Check if the response is valid
			if (!response.IsValidResponse)
			{
				// Return empty result if the query fails
				return new PageResult<TModel>(new List<TModel>(), 0, page, pageSize);
			}

			// Map the results to PageResult
			return new PageResult<TModel>(
				items: response.Documents?.ToList() ?? new List<TModel>(),
				totalItems: (int)response.Total, // Total hits from Elasticsearch
				pageIndex: page,
				pageSize: pageSize
			);
		}

		public async Task<bool> Remove(string key)
		{
			var response = await _elasticsearchClient.DeleteAsync<TModel>(key, d => d.Index(_elasticsearchSettings.DefaultIndex));

			return response.IsValidResponse;
		}

		public async Task<long?> RemoveAll()
		{
			var response = await _elasticsearchClient.DeleteByQueryAsync<TModel>(d => d.Indices(_elasticsearchSettings.DefaultIndex));

			return response.IsValidResponse ? response.Deleted : default;
		}
	}
}
