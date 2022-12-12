using System;
using Microsoft.AspNetCore.Mvc;
using Grupp2.Services;
using Grupp2.Models;

namespace Grupp2.Controllers;

[Controller]
[Route("api/[controller]")]
[Produces("application/json")]
public class RoutesController : Controller
{

    private readonly RoutesMongoDBService _mongoDBService;

    public RoutesController(RoutesMongoDBService mongoDBService)
    {
        _mongoDBService = mongoDBService;
    }



    [HttpGet]
    public async Task<List<Routes>> Get()
    {
        return await _mongoDBService.GetAsync();
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Routes routes)
    {
        await _mongoDBService.CreateAsync(routes);
        return CreatedAtAction(nameof(Get), new { id = routes.Id }, routes);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AddToRoutes(string id, [FromBody] string routesId)
    {
        await _mongoDBService.AddToRoutesAsync(id, routesId);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await _mongoDBService.DeleteAsync(id);
        return NoContent();
    }

}