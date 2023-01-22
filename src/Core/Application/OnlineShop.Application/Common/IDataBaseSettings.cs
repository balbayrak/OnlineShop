namespace OnlineShop.Application.Common
{
    public interface IDataBaseSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
