namespace TicketWise.Application.Features.Events.Commands.UpdateEvent;
public sealed class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand>
{
    private readonly IEventRepository _eventRepository;
    private readonly IMapper _mapper;

    public UpdateEventCommandHandler(IEventRepository eventRepository,
        IMapper mapper)
    {
        _eventRepository = eventRepository ??
            throw new ArgumentNullException(nameof(eventRepository));
        _mapper = mapper ??
            throw new ArgumentNullException(nameof(mapper));
    }

    public async Task Handle(
        UpdateEventCommand request,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(nameof(request));

        var eventToUpdate = await _eventRepository.GetByIdAsync(request.EventId);

        _mapper.Map(request, eventToUpdate,
            typeof(UpdateEventCommand), typeof(EventEntity));

        await _eventRepository.UpdateAsync(eventToUpdate);
    }
}
