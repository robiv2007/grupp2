using System;
using Microsoft.AspNetCore.Mvc;
using Grupp2.Services;
using Grupp2.Models;

namespace Grupp2.Controllers;

[Controller]
[Route("api/[controller]")]
[Produces("application/json")]

#pragma warning disable CS1591
public class InspectionsController: Controller {
    
    private readonly InspectionsDBService _inspectionsDBService;

    public InspectionsController(InspectionsDBService inspectionsDBService) {
        _inspectionsDBService = inspectionsDBService;
    }

    /// <summary>
    /// Gets all inspections items from list.
    /// </summary>
    [HttpGet]
    public async Task<List<Inspections>> Get() {   
        return await _inspectionsDBService.GetAsync();
    }

    /// <summary>
    /// Gets an item by id.
    /// </summary>
         [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Inspections>> Get(string id)
    {
        var inspection = await _inspectionsDBService.GetOneAsync(id);

        if (inspection is null)
        {
            return NotFound();
        }
        return inspection;
    }

    /// <summary>
    /// Creates a new inspection item.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     Create /Inspection
    /// {
    ///"_Id": "string",
    ///"certificate_number": 0,
    ///"business_name": "string",
    ///"date": "string",
    ///"result": "string",
    ///"sector": "string",
    ///"address": {
    ///"city": "string",
    ///"zip": 0,
    ///"street": "string",
    ///"number": 0
    ///},
    ///"string": [
    ///"string"
    ///]
    ///}
    /// </remarks>  

    /// <response code="201">Returns the newly created item</response>
    /// <response code="404">Item not found</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)] 
    public async Task<IActionResult> Post([FromBody] Inspections inspections) {
        await _inspectionsDBService.CreateAsync(inspections);
        return CreatedAtAction(nameof(Get), new { id = inspections._Id }, inspections);
    }

    /// <summary>
    /// Adds new item to list.
    /// </summary>
    /// <response code="404">Item not found</response>
    /// <response code="102">Processing request</response>
    
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)] 
    [ProducesResponseType(StatusCodes.Status102Processing)] 
    public async Task<IActionResult> AddToInspections(string id, [FromBody] string trainingId) {
        await _inspectionsDBService.AddToInspectionsAsync(id, trainingId);
        return NoContent();
}

    /// <summary>
    /// Deletes a specific inspections item.
    /// </summary>
     /// <response code="404">Item not found</response>
    /// <response code="102">Processing request</response>
    /// <response code="204">No item of such content exists</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)] 
    [ProducesResponseType(StatusCodes.Status102Processing)]
    [ProducesResponseType(StatusCodes.Status204NoContent)] 
        public async Task<IActionResult> Delete(string id) {
        await _inspectionsDBService.DeleteAsync(id);
        return NoContent();

    }

}

