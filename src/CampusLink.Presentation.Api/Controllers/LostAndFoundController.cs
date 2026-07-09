using CampusLink.Application.DTOs;
using CampusLink.Application.Services;
using CampusLink.Presentation.Api.Contracts.Requests;
using CampusLink.Presentation.Api.Contracts.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CampusLink.Presentation.Api.Controllers;

/// <summary>
/// Exposes lost-and-found endpoints.
/// </summary>
[ApiController]
[Route("api/v1/lost-found/reports")]
public sealed class LostAndFoundController : ControllerBase
{
    private readonly ILostItemReportService _lostItemReportService;

    /// <summary>
    /// Initializes a new instance of the <see cref="LostAndFoundController"/> class.
    /// </summary>
    /// <param name="lostItemReportService">Lost-item report service.</param>
    public LostAndFoundController(ILostItemReportService lostItemReportService)
    {
        _lostItemReportService = lostItemReportService;
    }

    /// <summary>
    /// Creates a lost item report.
    /// </summary>
    /// <param name="request">Request payload.</param>
    /// <param name="cancellationToken">Cancellation signal.</param>
    /// <returns>Created report response.</returns>
    [HttpPost]
    [ProducesResponseType(typeof(LostItemReportResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status422UnprocessableEntity)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<LostItemReportResponse>> CreateAsync(
        [FromBody] CreateLostItemReportRequest request,
        CancellationToken cancellationToken)
    {
        var created = await _lostItemReportService.CreateAsync(
            new CreateLostItemReportCommand(request.Title, request.Description, request.ContactEmail, request.Campus),
            cancellationToken);

        return CreatedAtRoute("GetLostItemReportById", new { reportId = created.Id }, Map(created));
    }

    /// <summary>
    /// Gets a lost item report by identifier.
    /// </summary>
    /// <param name="reportId">Report identifier.</param>
    /// <param name="cancellationToken">Cancellation signal.</param>
    /// <returns>Matching report response.</returns>
    [HttpGet("{reportId:guid}", Name = "GetLostItemReportById")]
    [ProducesResponseType(typeof(LostItemReportResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<LostItemReportResponse>> GetByIdAsync(Guid reportId, CancellationToken cancellationToken)
    {
        var report = await _lostItemReportService.GetByIdAsync(reportId, cancellationToken);

        if (report is null)
        {
            return NotFound(new ApiErrorResponse("not_found", "Lost item report was not found.", HttpContext.TraceIdentifier));
        }

        return Ok(Map(report));
    }

    private static LostItemReportResponse Map(LostItemReportDto dto) =>
        new(dto.Id, dto.Title, dto.Description, dto.ContactEmail, dto.Campus, dto.CreatedUtc);
}
