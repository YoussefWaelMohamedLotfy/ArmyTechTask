namespace ArmyTechTask.Domain.Repositories;

public interface IInvoiceHeaderRepository : IGenericRepository<InvoiceHeader>
{
    Task<InvoiceHeader> GetInvoiceHeadersWithRelations(long id, CancellationToken cancellationToken = default!);
}
