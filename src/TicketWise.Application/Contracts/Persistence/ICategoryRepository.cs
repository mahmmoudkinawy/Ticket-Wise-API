namespace TicketWise.Application.Contracts.Persistence;
public interface ICategoryRepository : IAsyncRepository<CategoryEntity>
{
    Task<IReadOnlyList<CategoryEntity>> GetCategoriesWithEventsAsync(bool includeHistory);
}
