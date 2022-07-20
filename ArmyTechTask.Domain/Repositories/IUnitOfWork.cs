namespace ArmyTechTask.Domain.Repositories;

public interface IUnitOfWork : IDisposable
{
    ICashierRepository Cashiers { get; }

    Task<int> SaveAsync(CancellationToken cancellationToken = default);
}