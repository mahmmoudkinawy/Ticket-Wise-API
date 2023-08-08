namespace TicketWise.Persistence.Repositories;
public sealed class OrderRepository : BaseRepository<OrderEntity>, IOrderRepository
{
    public OrderRepository(TicketWiseDbContext context) : base(context) { }

    public async Task<List<OrderEntity>> GetPagedOrdersForMonthAsync(
        DateTime date, int page, int size)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(nameof(date));
        ArgumentNullException.ThrowIfNullOrEmpty(nameof(page));
        ArgumentNullException.ThrowIfNullOrEmpty(nameof(size));

        return await _context.Orders
            .Where(x => x.OrderPlaced.Value.Year == date.Year &&
                x.OrderPlaced.Value.Month == date.Month)
            .Skip((page - 1) * size)
            .Take(size)
            .ToListAsync();
    }

    public async Task<int> GetTotalCountOfOrdersForMonthAsync(DateTime date)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(nameof(date));

        return await _context.Orders
            .CountAsync(x => x.OrderPlaced.Value.Year == date.Year &&
                x.OrderPlaced.Value.Month == date.Month);
    }
}
