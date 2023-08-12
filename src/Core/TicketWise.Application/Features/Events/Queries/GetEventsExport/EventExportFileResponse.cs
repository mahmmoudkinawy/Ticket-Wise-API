namespace TicketWise.Application.Features.Events.Queries.GetEventsExport;
public sealed record EventExportFileResponse(
    string ContentType,
    string EventExportFileName,
    byte[]? Data);
