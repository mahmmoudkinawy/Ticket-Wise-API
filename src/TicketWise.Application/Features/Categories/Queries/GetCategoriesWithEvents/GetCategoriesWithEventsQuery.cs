namespace TicketWise.Application.Features.Categories.Queries.GetCategoriesWithEvents;
public sealed record GetCategoriesWithEventsQuery
    (bool IncludeHistory = false) : IRequest<IReadOnlyList<CategoryEventResponse>>;