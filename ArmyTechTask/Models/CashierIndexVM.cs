using ArmyTechTask.Domain;

namespace ArmyTechTask.Models;

public class CashierIndexVM
{
    public IEnumerable<Cashier> Cashiers { get; set; } = default!;
}
