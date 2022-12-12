using System;
using Microsoft.AspNetCore.Mvc;
using Grupp2.Services;
using Grupp2.Models;

namespace Grupp2.Controllers;

[Controller]
[Route("api/[controller]")]
[Produces("application/json")]

#pragma warning disable CS1591

public class RoutesController : Controller
{

    private readonly RoutesMongoDBService _mongoDBService;

    public RoutesController(RoutesMongoDBService mongoDBService)
    {
        _mongoDBService = mongoDBService;
    }

    /// <summary>
    /// Gets all routes from the list.
    /// </summary>
    [HttpGet]
    public async Task<List<Routes>> Get()
    {
        return await _mongoDBService.GetAsync();
    }

    /// <summary>
    ///Gets a specific route by its ID.
    /// </summary>
    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Routes>> Get(string id)
    {
        var routes = await _mongoDBService.GetOneAsync(id);

        if (routes is null)
        {
            return NotFound();
        }
        return routes;
    }

    /// <summary>
    ///Creates a new route.
    /// </summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Post([FromBody] Routes routes)
    {
        await _mongoDBService.CreateAsync(routes);
        return CreatedAtAction(nameof(Get), new { id = routes.Id }, routes);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status102Processing)]
    public async Task<IActionResult> AddToRoutes(string id, [FromBody] string routesId)
    {
        await _mongoDBService.AddToRoutesAsync(id, routesId);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status102Processing)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Delete(string id)
    {
        await _mongoDBService.DeleteAsync(id);
        return NoContent();
    }

}