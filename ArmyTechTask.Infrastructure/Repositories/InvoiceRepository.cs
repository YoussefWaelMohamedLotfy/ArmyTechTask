using ArmyTechTask.Domain;
using ArmyTechTask.Domain.Repositories;
using ArmyTechTask.Infrastructure.Data;

namespace ArmyTechTask.Infrastructure.Repositories;

public class InvoiceRepository : GenericRepository<Invoice>, IInvoiceRepository
{
    public InvoiceRepository(AppDbContext context) : base(context)
    {
    }
}
