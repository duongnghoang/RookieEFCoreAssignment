namespace Application.Interfaces
{
    public interface ITransactionManager
    {
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
    }
}
