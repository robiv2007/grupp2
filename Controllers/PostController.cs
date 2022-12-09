using System;
using Microsoft.AspNetCore.Mvc;
using Grupp2.Services;
using Grupp2.Models;

namespace Grupp2.Controllers;


[Controller]
[Route("api/[controller]")]
public class PostController: Controller {
    
    private readonly PostMongoDBService _mongoDBService;

    public PostController(PostMongoDBService mongoDBService) {
        _mongoDBService = mongoDBService;
    }

    [HttpGet]
    public async Task<List<Posts>> Get() {
        return await _mongoDBService.GetAsync();
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Posts posts) {
        await _mongoDBService.CreateAsync(posts);
        return CreatedAtAction(nameof(Get), new { id = posts.Id }, posts);
    }

    // [HttpPut("{id}")]
    // public async Task<IActionResult> AddToPlaylist(string id, [FromBody] string movieId) {}

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id) {
        await _mongoDBService.DeleteAsync(id);
        return NoContent();
    }

}