namespace TicketWise.Api.Controllers;

[Route("api/categories")]
[ApiController]
public sealed class CategoriesController : ControllerBase
{
    private readonly IMediator _mediator;

    public CategoriesController(IMediator mediator)
    {
        _mediator = mediator ??
            throw new ArgumentNullException(nameof(mediator));
    }

    [HttpGet(Name = "GetCategories")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetCategories(
        CancellationToken cancellationToken)
    {
        var response = await _mediator
            .Send(new GetCategoriesQuery { }, cancellationToken);

        return Ok(response);
    }

    [HttpGet("categories-with-events", Name = "GetCategoriesWithEvents")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetCategoriesWithEvents(
        [FromQuery] bool includeHistory,
        CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(
            new GetCategoriesWithEventsQuery
            {
                IncludeHistory = includeHistory
            }, cancellationToken);

        return Ok(response);
    }

    [HttpPost(Name = "CreateCategory")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateCategory(
          [FromBody] CreateEventCommand command,
          CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(command, cancellationToken);

        return Ok(response);
    }

}
