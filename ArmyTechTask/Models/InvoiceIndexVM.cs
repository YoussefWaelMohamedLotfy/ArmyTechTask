using ArmyTechTask.Domain;

namespace ArmyTechTask.Models;

public class InvoiceIndexVM
{
    public IEnumerable<Invoice> Invoices { get; set; } = default!;
}
