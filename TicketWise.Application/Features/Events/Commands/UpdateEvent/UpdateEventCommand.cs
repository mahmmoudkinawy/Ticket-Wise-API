namespace TicketWise.Application.Features.Events.Commands.UpdateEvent;
public sealed record UpdateEventCommand(
    Guid EventId,
    string Name,
    int Price,
    string? Artist,
    DateTime Date,
    string? Description,
    string? ImageUrl,
    Guid CategoryId) : IRequest;
