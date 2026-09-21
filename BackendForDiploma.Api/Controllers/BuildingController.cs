using BackendForDiploma.Api.CQRS.Command.Buildings.CreateBuilding;
using BackendForDiploma.Api.CQRS.Command.Buildings.DeleteBuilding;
using BackendForDiploma.Api.CQRS.Query.Buildings.GetAllBuildings;
using BackendForDiploma.Api.CQRS.Query.Buildings.GetBuildingId;
using BackendForDiploma.Api.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BuildingsBackend.Api.Controllers;

/// <summary>
/// Контроллер для работы со зданиями
/// </summary>
[ApiController]
[Route("api/buildings")]
public class BuildingsController : ControllerBase
{
    private readonly IMediator _mediator;
    public BuildingsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Получить все здания
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<List<BuildingDto>>> GetAll()
    {
       return Ok(await _mediator.Send(new GetAllBuildingsQuery()));
    }

    /// <summary>
    /// Получить здание по id
    /// </summary>
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<BuildingDto>> GetById(Guid id)
    {
        var result = await _mediator.Send(new GetBuildingByIdQuery(id));

        return result is null ? NotFound() : Ok(result);
    }

    /// <summary>
    /// Добавить здание
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<BuildingDto>> Create([FromBody] CreateBuildingCommand command)
    {
        var result = await _mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    /// <summary>
    /// Обновить здание
    /// </summary>
    [HttpPut("{id:guid}")]
    public async Task<ActionResult<BuildingDto>> Update(Guid id, [FromBody] UpdateBuildingRequest body)
    {
        var result = await _mediator.Send(new UpdateBuildingCommand(
            id, body.Name, body.Description, body.ModelObjectKey, body.ModelFormat));

        return result is null ? NotFound() : Ok(result);
    }

    /// <summary>
    /// Удалить здание
    /// </summary>
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var success = await _mediator.Send(new DeleteBuildingCommand(id));

        return success ? NoContent() : NotFound();
    }
}