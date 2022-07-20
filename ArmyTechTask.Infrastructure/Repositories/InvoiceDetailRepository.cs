using ArmyTechTask.Domain;
using ArmyTechTask.Domain.Repositories;
using ArmyTechTask.Infrastructure.Data;

namespace ArmyTechTask.Infrastructure.Repositories;

public class InvoiceDetailRepository : GenericRepository<InvoiceDetail>, IInvoiceDetailRepository
{
    public InvoiceDetailRepository(AppDbContext context) : base(context)
    {
    }
}
