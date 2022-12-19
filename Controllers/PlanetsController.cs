using System;
using Microsoft.AspNetCore.Mvc;
using Grupp2.Services;
using Grupp2.Models;

namespace Grupp2.Controllers;



[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]



#pragma warning disable CS1591
public class PlanetsController : Controller
{

    private readonly PlanetMongoDBService _planetDBService;

    public PlanetsController(PlanetMongoDBService planetDBService)
    {
        _planetDBService = planetDBService;
    }


    /// <summary>
    ///  Get all the items in the list
    /// </summary>
    [HttpGet]
    public async Task<List<Planet>> Get()
    {
        return await _planetDBService.GetAsync();
    }

    /// <summary>
    ///  Creates a new planet item with id (when using Try it out delete id in model before you execute)
    /// </summary>
    /// <returns>A newly created planet item</returns>
    /// <remarks>
    /// Sample request
    ///
    ///     POST /Planet
    ///     {
    ///         "_Id": "string",
    ///         "name": "string",
    ///         "orderFromSun": 0,
    ///         "hasRings": true,
    ///         "mainAtmosphere": [
    ///         "string"
    ///     ],
    ///        "surfaceTemperatureC": {
    ///         "min": 0,
    ///         "max": 0,
    ///         "mean": 0
    ///     }
    ///}
    ///
    /// </remarks>
    /// <response code="401">Unauthorized</response>
    /// <response code="404">Not Found</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Post([FromBody] Planet planets)
    {
        await _planetDBService.CreateAsynk(planets);
        return CreatedAtAction(nameof(Get), new { id = planets._Id }, planets);
    }

    /// <summary>
    ///  Update an planet item in the list
    /// </summary>
    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Planet updatedPlanet)
    {
        var planet = await _planetDBService.GetAsync(id);

        if (planet is null)
        {
            return NotFound();
        }

        updatedPlanet._Id = planet._Id;

        await _planetDBService.UpdateAsync(id, updatedPlanet);

        return NoContent();
    }

    /// <summary>
    ///  Deletes a specific planet item
    /// </summary>
    /// <response code="400">Invalid ID supplied</response>
    /// <response code="404">Planet not found</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)] 
    public async Task<IActionResult> Delete(string id)
    {
        await _planetDBService.DeleteAsync(id);
        return NoContent();
    }

    /// <summary>
    ///  Gets one planet item from the Planets list based on the id
    /// </summary>
    /// <response code="400">Invalid ID supplied</response>
    /// <response code="404">Planet not found</response>

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)] 
    public async Task<ActionResult<Planet>> Get(string id)
    {
        // Use the collection to find user by ID
        var planet = await _planetDBService.GetOneById(id);

        if (planet is null)
        {
            return NotFound();
        }
        return planet;
    }

}
#pragma warning restore CS1591