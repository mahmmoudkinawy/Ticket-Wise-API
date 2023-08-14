namespace TicketWise.Application.Mappers;
public sealed class EventsMapperProfile : Profile
{
    public EventsMapperProfile()
    {
        CreateMap<EventEntity, Features.Events.Queries.GetEvents.EventResponse>();
        CreateMap<EventEntity, Features.Categories.Queries.GetCategoriesWithEvents.EventResponse>();
        CreateMap<EventEntity, EventDetailResponse>();
        CreateMap<EventEntity, EventCsvResponse>();
    }
}
