using ArmyTechTask.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using ArmyTechTask.Domain;
using ArmyTechTask.Infrastructure.Data;

namespace ArmyTechTask.Infrastructure.Repositories;

public class CashierRepository : GenericRepository<Cashier>, ICashierRepository
{
    public CashierRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Cashier> GetCashierByIdAsync(long id, CancellationToken cancellationToken = default!)
    {
        return (await _context.Cashiers.SingleOrDefaultAsync(x => x.Id == id))!;
    }
}
