using Application.Interfaces;
using Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infrastructure.Persistence.Transactions;

public sealed class TransactionManager : ITransactionManager, IDisposable
{
    private readonly ApplicationDbContext _dbContext;
    private IDbContextTransaction? _transaction;

    public TransactionManager(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task BeginTransactionAsync()
    {
        _transaction ??= await _dbContext.Database.BeginTransactionAsync();
    }

    public async Task CommitTransactionAsync()
    {
        if (_transaction != null)
        {
            await _transaction.CommitAsync();
            await _transaction.DisposeAsync();
            _transaction = null;
        }
    }

    public async Task RollbackTransactionAsync()
    {
        if (_transaction != null)
        {
            await _transaction.RollbackAsync();
            await _transaction.DisposeAsync();
            _transaction = null;
        }
    }

    public void Dispose()
    {
        _transaction?.Dispose();
    }
}