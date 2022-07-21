using ArmyTechTask.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ArmyTechTask.Models;

public class CashierUpsertVM
{
    public Cashier Cashier { get; set; } = default!;

    public IEnumerable<SelectListItem> BranchSelectList { get; set; } = default!;
}
