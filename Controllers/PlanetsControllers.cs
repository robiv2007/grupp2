using System;
using Microsoft.AspNetCore.Mvc;
using Grupp2.Services;
using Grupp2.Models;

namespace Grupp2.Controllers; 

[Controller]
[Route("api/[controller]")]
//[Produces("application/json")]
public class PlanetsController: Controller {
    
    private readonly PlanetMongoDBService _planetDBService;

    public PlanetsController(PlanetMongoDBService planetDBService) {
        _planetDBService = planetDBService;
    }



     [HttpGet]
     public async Task<List<Planets>> Get() {
        return await _planetDBService.GetAsync();
     }

     [HttpPost]
     public async Task<IActionResult> Post([FromBody] Planets planets) {
        await _planetDBService.CreateAsynk(planets);
        return CreatedAtAction(nameof(Get),new {id = planets._Id} , planets);
     }

     [HttpPut("{id}")]
      public async Task<IActionResult> AddToPlaylist(string id, [FromBody] string planetId) {
        await _planetDBService.AddToPlaylistAsync(id, id);
        return NoContent();
      }

     [HttpDelete("{id}")]
     public async Task<IActionResult> Delete(string id) {
        await _planetDBService.DeleteAsync(id);
        return NoContent();
     }
   [HttpGet("{id}")]
      public async Task<ActionResult<Planets>> Get(string id)
    {
        var planet = await _planetDBService.GetOneById(id);

        if (planet is null)
        {
            return NotFound();
        }
        return planet;
    }

}