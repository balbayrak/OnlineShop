namespace OnlineShop.Application.Repositories
{
    public interface ITransactionBuilder
    {
        Task BeginTransactionAsync();

        Task CommitTransactionAsync();

        Task RollbackTransactionAsync();

        void DisposeTransaction();
    }
}
