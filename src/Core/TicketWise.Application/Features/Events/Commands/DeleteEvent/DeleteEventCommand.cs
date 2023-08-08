namespace TicketWise.Application.Features.Events.Commands.DeleteEvent;
public sealed record DeleteEventCommand(Guid EventId) : IRequest<bool>;
