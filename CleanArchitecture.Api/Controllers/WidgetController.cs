using CleanArchitecture.Application.Commands;
using CleanArchitecture.Application.Queries;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace CleanArchitecture.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WidgetController(ILogger<WidgetController> logger, ISender sender) : ControllerBase
{
    [HttpPost("")]
    public async Task<IActionResult> AddAsync([FromBody] WidgetEntity widget)
    {
        logger.LogInformation("Adding widget.");
        var result = await sender.Send(new AddWidgetCommand(widget));
        return Ok(result);
    }

    [HttpGet("")]
    public async Task<IActionResult> GetAllWidgetsAsync()
    {
        var result = await sender.Send(new GetAllWidgetsQuery());
        return Ok(result);
    }

    [HttpGet("{widgetId}")]
    public async Task<IActionResult> GetWidgetByIdAsync([FromRoute] Guid widgetId)
    {
        var result = await sender.Send(new GetWidgetByIdQuery(widgetId));
        return Ok(result);
    }

    [HttpPut("{widgetId}")]
    public async Task<IActionResult> UpdateWidgetAsync([FromRoute] Guid widgetId, [FromBody] WidgetEntity widget)
    {
        var result = await sender.Send(new UpdateWidgetCommand(widgetId, widget));
        return Ok(result);
    }

    [HttpDelete("{widgetId}")]
    public async Task<IActionResult> DeleteWidgetAsync([FromRoute] Guid widgetId)
    {
        var result = await sender.Send(new DeleteWidgetCommand(widgetId));
        return Ok(result);
    }
}
