namespace TicketWise.Application.Features.Events.Queries.GetEvents;
public sealed record EventResponse(
    Guid Id,
    string Name,
    DateTime Date,
    string ImageUrl);