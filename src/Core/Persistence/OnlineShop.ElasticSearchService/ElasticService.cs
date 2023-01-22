using Microsoft.Extensions.Configuration;
using Nest;
using OnlineShop.Application.Wrappers;

namespace OnlineShop.ElasticSearchService
{
    public abstract class ElasticService<T> : IElasticService<T>
        where T : class, new()
    {
        public abstract string IndexName { get; }

        private readonly IConfiguration _configuration;

        private const string ELASTIC_CONFIGURATION_NAME = "ElasticConfiguration";
        public IElasticClient ElasticClient { get; }
        public ElasticService(IConfiguration configuration)
        {
            _configuration = configuration;

            var elasticConf = _configuration.GetSection(ELASTIC_CONFIGURATION_NAME);
            if (elasticConf is null)
            {
                throw new Exception($"{ELASTIC_CONFIGURATION_NAME} section not found in appsettings");
            }

            var elasticUri = new Uri(elasticConf["Uri"]);
            var settings = new ConnectionSettings(elasticUri);
            ElasticClient = new ElasticClient(settings);

        }
        public async Task<ServiceResponse<bool>> Insert(T data)
        {
            var response = await ElasticClient.IndexAsync(data, request => request.Index(IndexName));

            if (response.IsValid)
            {
                return new ServiceResponse<bool>
                {
                    IsSuccess = true,
                    Value = true
                };
            }

            return new ServiceResponse<bool>
            {
                IsSuccess = false,
                Value = false,
                Errors= new List<string> { response.ServerError?.ToString() }
            };
        }
    }
}
