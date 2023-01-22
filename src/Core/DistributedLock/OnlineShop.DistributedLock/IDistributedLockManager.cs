namespace OnlineShop.DistributedLock
{
    public interface IDistributedLockManager
    {
        void Lock(string key, Action action, CancellationToken? cancellationToken = null);
        ValueTask LockAsync(string key, Func<Task> action, CancellationToken? cancellationToken = null);
    }
}