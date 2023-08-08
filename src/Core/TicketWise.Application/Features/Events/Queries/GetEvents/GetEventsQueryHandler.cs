namespace TicketWise.Application.Features.Events.Queries.GetEvents;
public sealed class GetEventsQueryHandler : IRequestHandler<GetEventsQuery, IReadOnlyList<EventResponse>>
{
    private readonly IEventRepository _eventRepository;
    private readonly IMapper _mapper;

    public GetEventsQueryHandler(
        IEventRepository eventRepository,
        IMapper mapper)
    {
        _eventRepository = eventRepository ??
            throw new ArgumentNullException(nameof(eventRepository));
        _mapper = mapper ??
            throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<IReadOnlyList<EventResponse>> Handle(
        GetEventsQuery request, 
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(nameof(request));

        var events = (await _eventRepository.GetAllAsync()).OrderBy(e => e.Date);

        return _mapper.Map<IReadOnlyList<EventResponse>>(events);
    }
}
