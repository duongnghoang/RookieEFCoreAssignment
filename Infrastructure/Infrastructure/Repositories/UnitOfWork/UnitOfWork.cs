using Infrastructure.Persistence.Data;

namespace Infrastructure.Repositories.UnitOfWork;

public class UnitOfWork 
{
    private readonly ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}