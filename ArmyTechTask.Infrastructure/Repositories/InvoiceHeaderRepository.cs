using ArmyTechTask.Domain;
using ArmyTechTask.Domain.Repositories;
using ArmyTechTask.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ArmyTechTask.Infrastructure.Repositories;

public class InvoiceHeaderRepository : GenericRepository<InvoiceHeader>, IInvoiceHeaderRepository
{
    public InvoiceHeaderRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<InvoiceHeader> GetInvoiceHeadersWithRelations(long id, CancellationToken cancellationToken = default!)
        => (await _context.InvoiceHeaders
            .Include(x => x.InvoiceDetails)
            .Include(x => x.Branch)
            .Include(x => x.Cashier)
            .FirstOrDefaultAsync(x => x.Id == id))!;
}
