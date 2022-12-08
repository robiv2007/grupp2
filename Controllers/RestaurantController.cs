using System;
using Microsoft.AspNetCore.Mvc;
using GRUPP2.Services;
using GRUPP2.Models;

namespace GRUPP2.Controllers;

[Controller]
[Route("api/[controller]")]
public class RestaurantController: Controller {

    private readonly MongoDBService _mongoDBService;

    public RestaurantController(MongoDBService mongoDBService) {
        _mongoDBService = mongoDBService;
    }

    [HttpGet]
    public async Task<List<Restaurant>> Get() {
        return await _mongoDBService.GetAsync();
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Restaurant restaurant) {
        await _mongoDBService.CreateAsync(restaurant);
        return CreatedAtAction(nameof(Get), new {id = restaurant.Id}, restaurant);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AddToRestaurant (string id, [FromBody] string restaurantId) {
        await _mongoDBService.AddToRestaurantAsync(id, restaurantId);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id) {
        await _mongoDBService.DeleteAsync(id);
        return NoContent();
    }

}