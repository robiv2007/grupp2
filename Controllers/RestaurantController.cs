using System;
using Microsoft.AspNetCore.Mvc;
using Grupp2.Services;
using Grupp2.Models;

namespace Grupp2.Controllers;

[Controller]
[Route("api/[controller]")]
[Produces("application/json")]

#pragma warning disable CS1591
public class RestaurantController : Controller
{

    private readonly RestaurantMongoDBService _restaurantMongoDBService;

    public RestaurantController(RestaurantMongoDBService restaurantMongoDBService)
    {
        _restaurantMongoDBService = restaurantMongoDBService;
    }

    /// <summary>
    /// Get all Restaurant items
    /// </summary>
    [HttpGet]
    public async Task<List<Restaurant>> Get()
    {
        return await _restaurantMongoDBService.GetAsync();
    }

    /// <summary>Create new Restaurant</summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /Restaurant
    ///     {
    ///        "_id": "139208a36d4f07b8933825a8",
    ///        "borough": "Texas",
    ///        "cuisine": "Barbeque",
    ///        "menuItems": [
    ///        "smoked ribs"
    ///     ],
    ///       "coordinates": {
    ///         "long": 18.063240,
    ///         "lat": 59.334591
    ///      }
    /// }
    /// </remarks>
    /// <response code="201">Request success in created Restaurant</response>
    /// <response code="404">Item not found</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Post([FromBody] Restaurant restaurant)
    {
        await _restaurantMongoDBService.CreateAsync(restaurant);
        return CreatedAtAction(nameof(Get), new { id = restaurant._id }, restaurant);
    }

    /// <summary>
    /// Adds new item to the list
    /// </summary>

    /// <response code="201">Item added successfully</response>
    /// <response code="404">Item not found</response>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AddToRestaurant(string id, [FromBody] string restaurantId)
    {
        await _restaurantMongoDBService.AddToRestaurantAsync(id, restaurantId);
        return NoContent();
    }

    /// <summary>
    /// Delete a certain restaurant item.
    /// </summary>
    /// <returns></returns>
    /// <response code="102">Processing request</response>
    /// <response code="204">No item of such content exists</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status102Processing)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Delete(string id)
    {
        await _restaurantMongoDBService.DeleteAsync(id);
        return NoContent();
    }

    /// <summary>
    /// Get an item by id.
    /// </summary>

    /// <response code="404">Item not found</response>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Restaurant>> Get(string id)
    {
        var restaurants = await _restaurantMongoDBService.GetOneById(id);

        if (restaurants is null)
        {
            return NotFound();
        }
        return restaurants;
    }

}