namespace TicketWise.Application.Features.Events.Queries.GetEventsExport;
public sealed record EventCsvResponse(
    Guid Id,
    string Name,
    int Price,
    string Artist,
    DateTime Date,
    string Description,
    string ImageUrl);
