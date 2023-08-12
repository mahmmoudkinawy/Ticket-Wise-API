using TicketWise.Application.Features.Events.Commands.DeleteEvent;
using TicketWise.Application.Features.Events.Commands.UpdateEvent;
using TicketWise.Application.Features.Events.Queries.GetEventDetail;
using TicketWise.Application.Features.Events.Queries.GetEvents;
using TicketWise.Application.Features.Events.Queries.GetEventsExport;

namespace TicketWise.Api.Controllers;

[Route("api/events")]
[ApiController]
public sealed class EventsController : ControllerBase
{
    private readonly IMediator _mediator;

    public EventsController(IMediator mediator)
    {
        _mediator = mediator ??
            throw new ArgumentNullException(nameof(mediator));
    }

    [HttpGet(Name = "GetEvents")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetEvents(
        CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(
            new GetEventsQuery { }, cancellationToken);

        return Ok(response);
    }

    [HttpGet("{eventId}", Name = "GetEventById")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetEventById(
       [FromRoute] Guid eventId,
       CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(
            new GetEventDetailQuery(eventId), cancellationToken);

        if (response is null)
        {
            return NotFound();
        }

        return Ok(response);
    }

    [HttpPost(Name = "CreateEvent")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> CreateEvent(
        [FromBody] CreateEventCommand command,
        CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(command, cancellationToken);

        return Ok(response);
    }

    [HttpPut(Name = "UpdateEvent")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateEvent(
        [FromBody] UpdateEventCommand command,
        CancellationToken cancellationToken)
    {
        await _mediator.Send(command, cancellationToken);

        return NoContent();
    }

    [HttpDelete("{eventId}", Name = "DeleteEvent")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteEvent(
        [FromRoute] Guid eventId,
        CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(
            new DeleteEventCommand(eventId), cancellationToken);

        if (!response)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpGet("exports", Name = "ExportEvents")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> ExportEvents(
        CancellationToken cancellationToken)
    {
        var file = await _mediator.Send(
            new GetEventsExportQuery { },
            cancellationToken);

        return File(file.Data, file.ContentType, file.EventExportFileName);
    }
}
