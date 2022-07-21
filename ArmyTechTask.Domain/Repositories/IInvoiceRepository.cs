using Microsoft.AspNetCore.Mvc.Rendering;

namespace ArmyTechTask.Domain.Repositories;

public interface IInvoiceRepository : IGenericRepository<Invoice>
{
    IEnumerable<SelectListItem> GetAllBranchesDropdownList();
    IEnumerable<SelectListItem> GetAllCashiersDropdownList();
}
