using ArmyTechTask.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ArmyTechTask.Domain.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly AppDbContext _context;
    private readonly DbSet<T> _db;

    public GenericRepository(AppDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _db = _context.Set<T>();
    }

    public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default!)
    {
        await _db.AddAsync(entity, cancellationToken);
        return entity;
    }

    public void Delete(T entity)
    {
        _db.Remove(entity);
    }

    public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default!)
    {
        return await _db.ToListAsync();
    }

    public async Task<T> GetByIdAsync(long id, CancellationToken cancellationToken = default!)
    {
        return (await _db.FindAsync(id, cancellationToken))!;
    }

    public T Update(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;

        return entity;
    }
}
