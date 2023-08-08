namespace TicketWise.Application.Features.Categories.Queries.GetCategories;
public sealed record GetCategoriesQuery : IRequest<IReadOnlyList<CategoryResponse>>;
