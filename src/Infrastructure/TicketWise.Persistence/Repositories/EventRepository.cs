namespace TicketWise.Persistence.Repositories;
public sealed class EventRepository : BaseRepository<EventEntity>, IEventRepository
{
    public EventRepository(TicketWiseDbContext context) : base(context) { }

    public async Task<bool> IsEventExistsAsync(Guid eventId)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(nameof(eventId));

        if(eventId == Guid.Empty)
        {
            throw new Exception("Can not parse eventId");
        }

        return await _context.Events.AnyAsync(e => e.Id == eventId);
    }

    public async Task<bool> IsEventNameAndDateUniqueAsync(
        string name, DateTime eventDate)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(nameof(name));
        ArgumentNullException.ThrowIfNullOrEmpty(nameof(eventDate));

        return await _context.Events.AnyAsync(e =>
            e.Name.Equals(name) &&
            e.Date.Value.Date.Equals(eventDate));
    }
}
