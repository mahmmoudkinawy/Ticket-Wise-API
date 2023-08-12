namespace TicketWise.Application.Contracts.Persistence;
public interface IOrderRepository : IAsyncRepository<OrderEntity>
{
    Task<IReadOnlyList<OrderEntity>> GetPagedOrdersForMonthAsync(DateTime date, int page, int size);
    Task<int> GetTotalCountOfOrdersForMonthAsync(DateTime date);
}
