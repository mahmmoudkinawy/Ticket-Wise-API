namespace TicketWise.Application.Mappers;
public sealed class EventsMapperProfile : Profile
{
    public EventsMapperProfile()
    {
        CreateMap<EventEntity, EventResponse>();
        CreateMap<EventEntity, EventDetailResponse>();
    }
}
