using ArmyTechTask.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ArmyTechTask.Models
{
    public class InvoiceDetailsEditVM
    {
        public InvoiceHeader Invoice { get; set; } = default!;

        public IEnumerable<SelectListItem> BranchSelectList { get; set; } = default!;

        public IEnumerable<SelectListItem> CashierSelectList { get; set; } = default!;

    }
}
