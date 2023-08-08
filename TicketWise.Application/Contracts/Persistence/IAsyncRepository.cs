namespace TicketWise.Application.Contracts.Persistence;
public interface IAsyncRepository<T> where T : AuditableEntity
{
    Task<IReadOnlyList<T>> GetAllAsync();
    Task<T> GetByIdAsync(Guid id);
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}
