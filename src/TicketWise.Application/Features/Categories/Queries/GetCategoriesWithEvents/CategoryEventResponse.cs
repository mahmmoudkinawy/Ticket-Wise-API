namespace TicketWise.Application.Features.Categories.Queries.GetCategoriesWithEvents;
public sealed record CategoryEventResponse (
    Guid Id,
    string Name,
    ICollection<EventResponse>? Events);