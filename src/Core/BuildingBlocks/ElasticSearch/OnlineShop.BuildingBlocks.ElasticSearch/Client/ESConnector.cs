using Microsoft.Extensions.Configuration;
using Nest;

namespace OnlineShop.BuildingBlocks.ElasticSearch.Client
{
    public class ESConnector : IESConnector
    {
        private readonly IConfigurationRoot _configurationRoot;

        private const string ELASTIC_CONFIGURATION_NAME = "ElasticConfiguration";

        public IElasticClient elasticClient { get; }

        public ESConnector(IConfigurationRoot configurationRoot)
        {
            _configurationRoot = configurationRoot;

            var elasticConf = _configurationRoot.GetSection(ELASTIC_CONFIGURATION_NAME);
            if (elasticConf is null)
            {
                throw new Exception($"{ELASTIC_CONFIGURATION_NAME} section not found in appsettings");
            }


            var elasticUri = new Uri(elasticConf["Uri"]);
            var settings = new ConnectionSettings(elasticUri);
            elasticClient = new ElasticClient(settings);

        }
    }
}
