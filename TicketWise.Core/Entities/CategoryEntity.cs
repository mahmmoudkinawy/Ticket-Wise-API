using TicketWise.Core.Common;

namespace TicketWise.Core.Entities;
public sealed class CategoryEntity : AuditableEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public ICollection<EventEntity>? Events { get; set; }
}
