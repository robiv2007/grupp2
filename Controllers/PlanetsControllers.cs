using System;
using Microsoft.AspNetCore.Mvc;
using Grupp2.Services;
using Grupp2.Models;

namespace Grupp2.Controllers; 

[Controller]
[Route("api/[controller]")]
public class PlanetsController: Controller {
    
    private readonly PlanetMongoDBService _mongoDBService;

    public PlanetsController(PlanetMongoDBService mongoDBService) {
        _mongoDBService = mongoDBService;
    }



     [HttpGet]
     public async Task<List<Planets>> Get() {
        return await _mongoDBService.GetAsync();
     }

     [HttpPost]
     public async Task<IActionResult> Post([FromBody] Planets planets) {
        await _mongoDBService.CreateAsynk(planets);
        return CreatedAtAction(nameof(Get),new {id = planets._id} , planets);
     }

     [HttpPut("{id}")]
      public async Task<IActionResult> AddToPlaylist(string id, [FromBody] string planetId) {
        await _mongoDBService.AddToPlaylistAsync(id, id);
        return NoContent();
      }

     [HttpDelete("{id}")]
     public async Task<IActionResult> Delete(string id) {
        await _mongoDBService.DeleteAsync(id);
        return NoContent();
     }

}