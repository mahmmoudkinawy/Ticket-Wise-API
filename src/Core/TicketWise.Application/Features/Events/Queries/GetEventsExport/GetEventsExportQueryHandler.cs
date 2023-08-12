namespace TicketWise.Application.Features.Events.Queries.GetEventsExport;
public sealed class GetEventsExportQueryHandler
    : IRequestHandler<GetEventsExportQuery, EventExportFileResponse>
{
    private readonly IEventRepository _eventRepository;
    private readonly ICsvExporter _csvExporter;
    private readonly IMapper _mapper;

    public GetEventsExportQueryHandler(
        IEventRepository eventRepository,
        ICsvExporter csvExporter,
        IMapper mapper)
    {
        _eventRepository = eventRepository ??
            throw new ArgumentNullException(nameof(eventRepository));
        _csvExporter = csvExporter ??
            throw new ArgumentNullException(nameof(csvExporter));
        _mapper = mapper ??
            throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<EventExportFileResponse> Handle(
        GetEventsExportQuery request, CancellationToken cancellationToken)
    {
        var eventsFromDb = (await _eventRepository.GetAllAsync()).OrderBy(_ => _.Date);

        var events = _mapper.Map<IReadOnlyList<EventCsvResponse>>(eventsFromDb);

        var csvFileData = await _csvExporter.ExportEventToCsvAsync(events);

        var csvExportFileData = new EventExportFileResponse(
            "text/csv",
             $"{DateTime.Now:yyyy-MM-dd HH-mm-ss}.csv",
             csvFileData);

        return csvExportFileData;
    }

}
