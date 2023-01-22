using Nest;

namespace OnlineShop.BuildingBlocks.ElasticSearch.Client
{
    public interface IESConnector
    {
        IElasticClient elasticClient { get; }
    }
}
