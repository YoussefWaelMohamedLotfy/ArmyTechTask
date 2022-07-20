namespace ArmyTechTask.Domain.Repositories;

public interface ICashierRepository : IGenericRepository<Cashier>
{
    Task<Cashier> GetCashierByIdAsync(long id, CancellationToken cancellationToken = default!);
}