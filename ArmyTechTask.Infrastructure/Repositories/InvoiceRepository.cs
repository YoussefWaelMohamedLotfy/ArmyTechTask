using ArmyTechTask.Domain;
using ArmyTechTask.Domain.Repositories;
using ArmyTechTask.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ArmyTechTask.Infrastructure.Repositories;

public class InvoiceRepository : GenericRepository<Invoice>, IInvoiceRepository
{
    public InvoiceRepository(AppDbContext context) : base(context)
    {
    }

    public IEnumerable<SelectListItem> GetAllBranchesDropdownList()
        => _context.Branches.Select(i => new SelectListItem
        {
            Text = i.BranchName,
            Value = i.Id.ToString()
        });

    public IEnumerable<SelectListItem> GetAllCashiersDropdownList()
        => _context.Cashiers.Select(i => new SelectListItem
        {
            Text = i.CashierName,
            Value = i.Id.ToString()
        });
}
