using Grupp2.Models;
using Grupp2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Grupp2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class THoughtController : ControllerBase{

private readonly ThoughtService _thoughtService;

public THoughtController(ThoughtService thoughtService) =>
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

}