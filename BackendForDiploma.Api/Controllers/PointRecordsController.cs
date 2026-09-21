using BackendForDiploma.Api.CQRS.Command.PointRecords.CreatePointRecord;
using BackendForDiploma.Api.CQRS.Command.PointRecords.DeletePointRecord;
using BackendForDiploma.Api.CQRS.Command.PointRecords.UpdatePointRecord;
using BackendForDiploma.Api.CQRS.Query.PointRecords.GetPointRecordById;
using BackendForDiploma.Api.CQRS.Query.PointRecords.GetRecordsByPoint;
using BackendForDiploma.Api.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BuildingsBackend.Api.Controllers;

/// <summary>
/// Контроллер для работы с записями информационных точек
/// </summary>
[ApiController]
[Route("api")]
public class PointRecordsController : ControllerBase
{
    private readonly IMediator _mediator;
    public PointRecordsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Получить все записи информационной точки
    /// </summary>
    [HttpGet("points/{pointId:guid}/records")]
    public async Task<ActionResult<List<PointRecordDto>>> GetByPoint(Guid pointId)
    {
        return Ok(await _mediator.Send(new GetRecordsByPointQuery(pointId)));
    }

    /// <summary>
    /// Получить запись информационной точки по id
    /// </summary>
    [HttpGet("records/{id:guid}")]
    public async Task<ActionResult<PointRecordDto>> GetById(Guid id)
    {
        var result = await _mediator.Send(new GetPointRecordByIdQuery(id));

        return result is null ? NotFound() : Ok(result);
    }

    /// <summary>
    /// Создать запись информационной точки
    /// </summary>
    [HttpPost("points/{pointId:guid}/records")]
    public async Task<ActionResult<PointRecordDto>> Create(Guid pointId, [FromBody] CreatePointRecordRequest body)
    {
        var result = await _mediator.Send(new CreatePointRecordCommand(
            body.Id, pointId, body.PhotoObjectKey, body.InspectionDate, body.State));

        return result is null
            ? NotFound("Точка не найдена.")
            : CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    /// <summary>
    /// Обновить запись информационной точки
    /// </summary>
    [HttpPut("records/{id:guid}")]
    public async Task<ActionResult<PointRecordDto>> Update(Guid id, [FromBody] UpdatePointRecordRequest body)
    {
        var result = await _mediator.Send(new UpdatePointRecordCommand(
            id, body.PhotoObjectKey, body.InspectionDate, body.State));

        return result is null ? NotFound() : Ok(result);
    }

    /// <summary>
    /// Удалить запись информационной точки
    /// </summary>
    [HttpDelete("records/{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var success = await _mediator.Send(new DeletePointRecordCommand(id));

        return success ? NoContent() : NotFound();
    }
}