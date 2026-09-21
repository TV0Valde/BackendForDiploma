using BackendForDiploma.Api.CQRS.Command.Points.CreatePointCommand;
using BackendForDiploma.Api.CQRS.Command.Points.DeletePointCommand;
using BackendForDiploma.Api.CQRS.Command.Points.UpdatePointCommand;
using BackendForDiploma.Api.CQRS.Query.Points.GetPointById;
using BackendForDiploma.Api.CQRS.Query.Points.GetPointsByBuilding;
using BackendForDiploma.Api.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BuildingsBackend.Api.Controllers;

/// <summary>
/// Контроллер для работы с информационными точками
/// </summary>
[ApiController]
[Route("api")]
public class PointsController : ControllerBase
{
    private readonly IMediator _mediator;
    public PointsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Получить все информационные точки здания
    /// </summary>
    [HttpGet("buildings/{buildingId:guid}/points")]
    public async Task<ActionResult<List<PointDto>>> GetByBuilding(Guid buildingId)
    {
        return Ok(await _mediator.Send(new GetPointsByBuildingQuery(buildingId)));
    }

    /// <summary>
    /// Получить информационную точку по id
    /// </summary>
    [HttpGet("points/{id:guid}")]
    public async Task<ActionResult<PointDto>> GetById(Guid id)
    {
        var result = await _mediator.Send(new GetPointByIdQuery(id));

        return result is null ? NotFound() : Ok(result);
    }

    /// <summary>
    /// Создать информационную точку для здания
    /// </summary>
    [HttpPost("buildings/{buildingId:guid}/points")]
    public async Task<ActionResult<PointDto>> Create(Guid buildingId, [FromBody] CreatePointRequest body)
    {
        var result = await _mediator.Send(new CreatePointCommand(
            body.Id, buildingId, body.SphereObjectName, body.X, body.Y, body.Z, body.CurrentColor));

        return result is null
            ? NotFound("Здание не найдено.")
            : CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    /// <summary>
    /// Обновить информационную точку
    /// </summary>
    [HttpPut("points/{id:guid}")]
    public async Task<ActionResult<PointDto>> Update(Guid id, [FromBody] UpdatePointRequest body)
    {
        var result = await _mediator.Send(new UpdatePointCommand(
            id, body.SphereObjectName, body.X, body.Y, body.Z, body.CurrentColor));

        return result is null ? NotFound() : Ok(result);
    }

    /// <summary>
    /// Удалить информационную точку
    /// </summary>
    [HttpDelete("points/{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var success = await _mediator.Send(new DeletePointCommand(id));
        return success ? NoContent() : NotFound();
    }
}