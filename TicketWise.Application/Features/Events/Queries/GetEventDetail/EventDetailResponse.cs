namespace TicketWise.Application.Features.Events.Queries.GetEventDetail;
public sealed record EventDetailResponse(
    Guid Id,
    string Name,
    int Price,
    string Artist,
    DateTime Date,
    string Description,
    string ImageUrl,
    string CategoryId)
{
    public CategoryResponse? Category { get; set; }
}