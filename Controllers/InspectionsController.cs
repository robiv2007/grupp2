using System;
using Microsoft.AspNetCore.Mvc;
using grupp2.Services;
using grupp2.Models;

namespace grupp2.Controllers; 

[Controller]
[Route("api/[controller]")]
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
    /// Creates a new inspection item.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /Inspection
    ///     {
    ///        {
    /// "id": "string",
    ///"certificate_number": 39,
    ///"date": "string",
    ///"business_name": "sanna",
    ///"result": "string",
    ///"sector": "string",
    ///"address": {
    /// "city": "string",
    ///"zip": 0,
    ///"street": "string",
    ///"number": 0
    ///}
    ///}
    ///     }
    ///
    /// </remarks>  
    
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Inspections inspections) {
        await _inspectionsDBService.CreateAsync(inspections);
        return CreatedAtAction(nameof(Get), new { id = inspections._Id }, inspections);
    }

    /// <summary>
    /// Add changes to a specific inpsections item.
    /// </summary>
    [HttpPut("{id}")]
    public async Task<IActionResult> AddToInspections(string id, [FromBody] string trainingId) {
        await _inspectionsDBService.AddToInspectionsAsync(id, trainingId);
        return NoContent();
}

    /// <summary>
    /// Deletes a specific inspections item.
    /// </summary>
    [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id) {
        await _inspectionsDBService.DeleteAsync(id);
        return NoContent();

    }

}
