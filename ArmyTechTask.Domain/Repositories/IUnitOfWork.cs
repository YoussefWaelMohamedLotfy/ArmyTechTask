namespace ArmyTechTask.Domain.Repositories;

public interface IUnitOfWork : IDisposable
{
    ICashierRepository Cashiers { get; }
    IInvoiceRepository Invoices { get; }

    Task<int> SaveAsync(CancellationToken cancellationToken = default);
}