using OpenSearch.Client;
using Microsoft.Extensions.Options;
using JobBee.Domain.Config;
using JobBee.Shared.Paginators;
using System.Linq.Expressions;

namespace JobBee.Application.ElasticSearchService
{
	public class ElasticSearchService<TModel> : IElasticSearchService<TModel> where TModel : class
	{
		private readonly IOpenSearchClient _client;
		private readonly ElasticSearchSettings _settings;

		public ElasticSearchService(IOptions<ElasticSearchSettings> options)
		{
			_settings = options.Value;

			var connectionSettings = new ConnectionSettings(new Uri(_settings.Url))
				.BasicAuthentication(_settings.Username, _settings.Password)
				.DefaultIndex(_settings.DefaultIndex);

			_client = new OpenSearchClient(connectionSettings);
		}

		public async Task<bool> AddOrUpdate(TModel model)
		{
			var response = await _client.IndexDocumentAsync(model);
			return response.IsValid;
		}

		public async Task<bool> AddOrUpdateBulk(IEnumerable<TModel> models, string indexName)
		{
			var response = await _client.BulkAsync(b => b
				.Index(indexName)
				.IndexMany(models)
			);
			return response.IsValid;
		}

		public async Task CreateIndexIfNotExistesAsync(string indexName)
		{
			var exists = await _client.Indices.ExistsAsync(indexName);
			if (!exists.Exists)
			{
				await _client.Indices.CreateAsync(indexName);
			}
		}

		public async Task<TModel?> Get(string key, string? index = null)
		{
			var response = await _client.GetAsync<TModel>(key, g => g.Index(index ?? _settings.DefaultIndex));
			return response.Found ? response.Source : null;
		}

		public async Task<PageResult<TModel>> GetList<TProperty>(
			Func<SearchDescriptor<TModel>, ISearchRequest>? searchConfig = null,
			Expression<Func<TModel, TProperty>>? orderBy = null,
			bool? ascending = true,
			int? page = 0,
			int? pageSize = 20,
			string? index = null)
		{
			var searchDescriptor = new SearchDescriptor<TModel>()
				.Index(index ?? _settings.DefaultIndex)
				.From((page ?? 0) * (pageSize ?? 20))
				.Size(pageSize ?? 20);

			// Apply search config
			if (searchConfig != null)
			{
				searchDescriptor = (SearchDescriptor<TModel>)searchConfig(searchDescriptor);
			}

			// Apply sorting
			if (orderBy != null)
			{
				var sortField = GetPropertyName(orderBy);
				searchDescriptor = searchDescriptor.Sort(s => ascending == true
					? s.Ascending(sortField)
					: s.Descending(sortField));
			}

			var response = await _client.SearchAsync<TModel>(searchDescriptor);

			if (!response.IsValid)
				throw new Exception("OpenSearch query failed: " + response.DebugInformation);

			return new PageResult<TModel>(response.Documents.ToList(), (int)response.Total, page!.Value, pageSize!.Value);
		}

		private string GetPropertyName<TProperty>(Expression<Func<TModel, TProperty>> expression)
		{
			if (expression.Body is MemberExpression member)
				return member.Member.Name;
			throw new ArgumentException("Expression must be a member expression");
		}

		public async Task<bool> Remove(string key, string? index = null)
		{
			var response = await _client.DeleteAsync<TModel>(key, d => d.Index(index ?? _settings.DefaultIndex));
			return response.IsValid;
		}

		public async Task<long?> RemoveAll(string? index = null)
		{
			var response = await _client.DeleteByQueryAsync<TModel>(q => q
				.Index(index ?? _settings.DefaultIndex)
				.Query(rq => rq.MatchAll())
			);

			return response.IsValid ? response.Deleted : default;
		}
	}
}
