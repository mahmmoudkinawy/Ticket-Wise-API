namespace TicketWise.Application.Contracts.Persistence;
public interface IEventRepository : IAsyncRepository<EventEntity>
{
    Task<bool> IsEventExistsAsync(Guid eventId);
    Task<bool> IsEventNameAndDateUniqueAsync(string name, DateTime eventDate);
}
