using System;
using Microsoft.AspNetCore.Mvc;
using Grupp2.Services;
using Grupp2.Models;

namespace Grupp2.Controllers; 

[Controller]
[Route("api/[controller]")]
public class SalesController: Controller {
    
    private readonly MongoDBService _mongoDBService;

    public SalesController(MongoDBService mongoDBService) {
        _mongoDBService = mongoDBService;
    }

    [HttpGet]
    public async Task<List<Sales>> Get() {
        return await _mongoDBService.GetAsync();
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Sales sales) {
        await _mongoDBService.CreateAsync(sales);
        return CreatedAtAction(nameof(Get), new { id = sales._id }, sales);
    }

    // [HttpPut("{id}")]
    // public async Task<IActionResult> AddToPlaylist(string id, [FromBody] string movieId) {}

    // [HttpDelete("{id}")]
    // public async Task<IActionResult> Delete(string id) {}

}