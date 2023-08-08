using TicketWise.Core.Common;

namespace TicketWise.Core.Entities;
public sealed class OrderEntity : AuditableEntity
{
    public Guid Id { get; set; }
    public Guid? UserId { get; set; }
    public int? OrderTotal { get; set; }
    public DateTime? OrderPlaced { get; set; }
    public bool? OrderPaid { get; set; }
}
