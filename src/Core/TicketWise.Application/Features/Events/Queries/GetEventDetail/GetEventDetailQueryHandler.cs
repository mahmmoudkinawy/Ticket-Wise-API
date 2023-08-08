namespace TicketWise.Application.Features.Events.Queries.GetEventDetail;
public sealed class GetEventDetailQueryHandler : IRequestHandler<GetEventDetailQuery, EventDetailResponse>
{
    private readonly IEventRepository _eventRepository;
    private readonly IMapper _mapper;

    public GetEventDetailQueryHandler(
        IEventRepository eventRepository,
        IMapper mapper)
    {
        _eventRepository = eventRepository ??
            throw new ArgumentNullException(nameof(eventRepository));
        _mapper = mapper ??
            throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<EventDetailResponse> Handle(GetEventDetailQuery request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(nameof(request));

        var @event = await _eventRepository.GetByIdAsync(request.EventId);

        if (@event is null)
        {
            return null;
        }

        var eventToReturn = _mapper.Map<EventDetailResponse>(@event);

        var category = await _eventRepository.GetByIdAsync(@event.CategoryId);

        eventToReturn.Category = _mapper.Map<CategoryResponse>(category);

        return eventToReturn;
    }
}
