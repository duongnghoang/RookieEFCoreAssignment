using Domain.Interfaces;
using Infrastructure.Persistence.Data;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Base;

public class BaseRepository<TEntity, TResponse> : IBaseRepository<TEntity, TResponse>
    where TEntity : class
    where TResponse : IResponseDto
{
    private protected readonly ApplicationDbContext Context;

    protected BaseRepository(ApplicationDbContext context)
    {
        Context = context;
    }

    public virtual async Task<TEntity?> GetByIdAsync(int id)
    {
        var entity = await Context.Set<TEntity>().FindAsync(id);

        return entity;
    }

    public virtual async Task<IEnumerable<TResponse>> GetAllAsync()
    {
        var entities = await Context.Set<TEntity>()
            .AsNoTracking()
            .ToListAsync();

        return entities.Adapt<IEnumerable<TResponse>>();
    }

    public virtual async Task AddAsync(TEntity entity)
    {
        await Context.Set<TEntity>().AddAsync(entity);
    }

    public virtual void Update(TEntity entity)
    {
        Context.Set<TEntity>().Update(entity);
    }

    public virtual void Delete(TEntity entity)
    {
        Context.Set<TEntity>().Remove(entity);
    }

    public async Task SaveChangesAsync()
    {
        await Context.SaveChangesAsync();
    }
}