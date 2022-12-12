using Grupp2.Models;
using Grupp2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Grupp2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ThoughtController : ControllerBase{

    private readonly ThoughtService _thoughtService;

    public ThoughtController(ThoughtService thoughtService) =>
    _thoughtService = thoughtService;

    [HttpGet]
    public async Task<List<Thought>> Get() =>
    await _thoughtService.GetAsync();

    [HttpPost]
    public async Task<IActionResult> Post(Thought newThought)
    {
        await _thoughtService.CreateAsync(newThought);
        return CreatedAtAction(nameof(Get), new { id = newThought.Id }, newThought);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Thought updatedThought)
    {
        var thought = await _thoughtService.GetAsync(id);

        if(thought is null)
        {
            return NotFound();
        }

        updatedThought.Id = thought.Id;

        await _thoughtService.UpdateAsync(id, updatedThought);
        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var thought = await _thoughtService.GetAsync(id);

        if(thought is null)
        {
            return NotFound();
        }

        await _thoughtService.DeleteAsync(id);

        return NoContent();         
    }

}