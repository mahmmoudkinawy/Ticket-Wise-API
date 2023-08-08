namespace TicketWise.Application.Features.Events.Commands.CreateEvent;
public sealed class CreateEventCommandHandler :
    IRequestHandler<CreateEventCommand, Guid>
{
    private readonly IEventRepository _eventRepository;
    private readonly IMapper _mapper;

    public CreateEventCommandHandler(IEventRepository eventRepository,
        IMapper mapper)
    {
        _eventRepository = eventRepository ??
            throw new ArgumentNullException(nameof(eventRepository));
        _mapper = mapper ??
            throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
    {
        var @event = _mapper.Map<EventEntity>(request);

        @event = await _eventRepository.AddAsync(@event);

        return @event.Id;
    }

}
