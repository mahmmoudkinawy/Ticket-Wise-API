namespace TicketWise.Application.Features.Events.Commands.DeleteEvent;
public sealed class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand, bool>
{
    private readonly IEventRepository _eventRepository;

    public DeleteEventCommandHandler(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository ??
            throw new ArgumentNullException(nameof(eventRepository));
    }

    public async Task<bool> Handle(
        DeleteEventCommand request,
        CancellationToken cancellationToken)
    {
        var eventToDelete = await _eventRepository.GetByIdAsync(request.EventId);

        if (eventToDelete is null)
        {
            return false;
        }

        await _eventRepository.DeleteAsync(eventToDelete);

        return true;
    }
}
