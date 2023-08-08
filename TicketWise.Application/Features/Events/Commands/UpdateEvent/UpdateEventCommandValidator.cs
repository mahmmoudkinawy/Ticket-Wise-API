namespace TicketWise.Application.Features.Events.Commands.UpdateEvent;
internal class UpdateEventCommandValidator : AbstractValidator<UpdateEventCommand>
{
    private readonly IEventRepository _eventRepository;

    public UpdateEventCommandValidator(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository ??
            throw new ArgumentNullException(nameof(eventRepository));

        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MaximumLength(50)
            .WithMessage("{PropertyName} must not exceed 50 characters.");

        RuleFor(p => p.Date)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .GreaterThan(DateTime.Now);

        RuleFor(e => e)
            .MustAsync(EventNameAndDateUnique)
            .WithMessage("An event with the same name and date already exists.");

        RuleFor(e => e.EventId)
            .MustAsync(IsEventExists)
            .WithMessage("There is no Event with the given EventId.");

        RuleFor(p => p.Price)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .GreaterThan(0);
    }

    private async Task<bool> IsEventExists(
        Guid eventId,
        CancellationToken cancellationToken)
    {
        return !(await _eventRepository.IsEventExistsAsync(eventId));
    }

    private async Task<bool> EventNameAndDateUnique(
        UpdateEventCommand e,
        CancellationToken cancellationToken)
    {
        return !(await _eventRepository.IsEventNameAndDateUniqueAsync(e.Name, e.Date));
    }
}
