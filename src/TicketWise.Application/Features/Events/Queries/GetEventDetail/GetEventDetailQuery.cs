namespace TicketWise.Application.Features.Events.Queries.GetEventDetail;
public sealed record GetEventDetailQuery
    (Guid EventId) : IRequest<EventDetailResponse>;