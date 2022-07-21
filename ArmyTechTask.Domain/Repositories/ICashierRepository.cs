using Microsoft.AspNetCore.Mvc.Rendering;

namespace ArmyTechTask.Domain.Repositories;

public interface ICashierRepository : IGenericRepository<Cashier>
{
    Task<IEnumerable<Cashier>> GetAllCashiersWithBranch(CancellationToken cancellationToken = default!);
    IEnumerable<SelectListItem> GetAllBranchesDropdownList();
    Task<Cashier> GetCashierByIdAsync(long id, CancellationToken cancellationToken = default!);
}