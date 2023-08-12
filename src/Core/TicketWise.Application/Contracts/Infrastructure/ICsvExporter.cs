namespace TicketWise.Application.Contracts.Infrastructure;
public interface ICsvExporter
{
    Task<byte[]> ExportEventToCsvAsync(IReadOnlyList<EventCsvResponse> events);
}
