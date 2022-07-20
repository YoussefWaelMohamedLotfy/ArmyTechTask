namespace ArmyTechTask.Domain.Repositories;

public interface IUnitOfWork : IDisposable
{
    ICashierRepository Cashiers { get; }
    IInvoiceRepository Invoices { get; }
    IInvoiceHeaderRepository InvoiceHeaders { get; }
    IInvoiceDetailRepository InvoiceDetails { get; }

    Task<int> SaveAsync(CancellationToken cancellationToken = default);
}