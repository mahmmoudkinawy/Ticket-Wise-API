namespace TicketWise.Application.Features.Events.Commands.CreateEvent;
public sealed record CreateEventCommand(
    string Name,
    int Price,
    string? Artist,
    DateTime Date,
    string? Description,
    string? ImageUrl,
    Guid CategoryId) : IRequest<Guid>;
