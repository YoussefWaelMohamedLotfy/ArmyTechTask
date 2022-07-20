using ArmyTechTask.Domain;
using ArmyTechTask.Domain.Repositories;
using ArmyTechTask.Infrastructure.Data;

namespace ArmyTechTask.Infrastructure.Repositories;

public class InvoiceHeaderRepository : GenericRepository<InvoiceHeader>, IInvoiceHeaderRepository
{
    public InvoiceHeaderRepository(AppDbContext context) : base(context)
    {
    }
}
