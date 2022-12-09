using System;
using Microsoft.AspNetCore.Mvc;
using GRUPP2.Services;
using GRUPP2.Models;

namespace GRUPP2.Controllers;

[Controller]
[Route("api/[controller]")]
public class RestaurantController: Controller {

    private readonly RestaurantMongoDBService _restaurantMongoDBService;

    public RestaurantController(RestaurantMongoDBService restaurantMongoDBService) {
        _restaurantMongoDBService = restaurantMongoDBService;
    }

    [HttpGet]
    public async Task<List<Restaurant>> Get() {
        return await _mongoDBService.GetAsync();
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Restaurant restaurant) {
        await _restaurantMongoDBService.CreateAsync(restaurant);
        return CreatedAtAction(nameof(Get), new {id = restaurant._id}, restaurant);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AddToRestaurant (string id, [FromBody] string restaurantId) {
        await _restaurantMongoDBService.AddToRestaurantAsync(id, restaurantId);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id) {
        await _restaurantMongoDBService.DeleteAsync(id);
        return NoContent();
    }

}