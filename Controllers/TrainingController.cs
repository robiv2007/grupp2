using System;
using Microsoft.AspNetCore.Mvc;
using grupp2.Services;
using grupp2.Models;

namespace grupp2.Controllers; 

[Controller]
[Route("api/[controller]")]
public class TrainingController: Controller {
    
    private readonly TrainingDBService _trainingDBService;

    public TrainingController(TrainingDBService mongoDBService) {
        _trainingDBService = mongoDBService;
    }

    [HttpGet]
    public async Task<List<Training>> Get() {   
        return await _trainingDBService.GetAsync();
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Training training) {
        await _trainingDBService.CreateAsync(training);
        return CreatedAtAction(nameof(Get), new { id = training.Id }, training);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AddToTraining(string id, [FromBody] string movieId) {
        await _trainingDBService.AddToTrainingAsync(id, movieId);
        return NoContent();
}

    [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id) {
        await _trainingDBService.DeleteAsync(id);
        return NoContent();

    }

}
