namespace TicketWise.Infrastructure.FileExport;
public sealed class CsvExporter : ICsvExporter
{
    public async Task<byte[]> ExportEventToCsvAsync(
        IReadOnlyList<EventCsvResponse> events)
    {
        using var memoryStream = new MemoryStream();
        using var streamWriter = new StreamWriter(memoryStream);
        using var csvWriter = new CsvWriter(
            streamWriter,
            System.Globalization.CultureInfo.CurrentCulture);
        await csvWriter.WriteRecordsAsync(events);

        return memoryStream.ToArray();
    }
}
