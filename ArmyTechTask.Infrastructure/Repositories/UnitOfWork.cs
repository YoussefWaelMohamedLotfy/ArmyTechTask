using ArmyTechTask.Domain.Repositories;
using ArmyTechTask.Infrastructure.Data;

namespace ArmyTechTask.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));

        Cashiers = new CashierRepository(_context);
    }

    public ICashierRepository Cashiers { get; private set; }

    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }

    public async Task<int> SaveAsync(CancellationToken cancellationToken = default!)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }
}
