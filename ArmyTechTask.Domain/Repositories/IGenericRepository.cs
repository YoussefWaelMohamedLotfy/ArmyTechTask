namespace ArmyTechTask.Domain.Repositories;

public interface IGenericRepository<T> where T : class
{
    Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);
    void Delete(T entity);
    Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<T> GetByIdAsync(long id, CancellationToken cancellationToken = default);
    T Update(T entity);
}