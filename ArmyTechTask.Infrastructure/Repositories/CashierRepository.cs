using ArmyTechTask.Domain.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ArmyTechTask.Domain;
using ArmyTechTask.Infrastructure.Data;

namespace ArmyTechTask.Infrastructure.Repositories;

public class CashierRepository : GenericRepository<Cashier>, ICashierRepository
{
    public CashierRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Cashier>> GetAllCashiersWithBranch(CancellationToken cancellationToken = default!) 
        => await _context.Cashiers
            .Include(x => x.Branch)
            .ToListAsync(cancellationToken);

    public async Task<Cashier> GetCashierByIdAsync(long id, CancellationToken cancellationToken = default!)
        => (await _context.Cashiers.SingleOrDefaultAsync(x => x.Id == id, cancellationToken))!;

    public IEnumerable<SelectListItem> GetAllBranchesDropdownList() 
        => _context.Branches.Select(i => new SelectListItem
        {
            Text = i.BranchName,
            Value = i.Id.ToString()
        });
}
