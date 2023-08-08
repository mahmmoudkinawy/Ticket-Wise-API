namespace TicketWise.Application.Features.Categories.Queries.GetCategoriesWithEvents;
public sealed record EventResponse(
    Guid Id,
    string Name,
    int Price,
    string Artist,
    DateTime Date,
    Guid CategoryId);
