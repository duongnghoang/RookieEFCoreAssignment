using Domain.Entities;

namespace Domain.Interfaces;

public interface IBaseRepository<TEntity, TResponse>
    where TEntity : class
    where TResponse : IResponseDto
{
    Task<TEntity?> GetByIdAsync(int id);
    Task<IEnumerable<TResponse>> GetAllAsync();
    Task AddAsync(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
    Task SaveChangesAsync();
}