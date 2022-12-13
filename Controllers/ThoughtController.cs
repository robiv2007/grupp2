using Grupp2.Models;
using Grupp2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Grupp2.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class ThoughtController : ControllerBase{

    private readonly ThoughtService _thoughtService;

    public ThoughtController(ThoughtService thoughtService) =>
    _thoughtService = thoughtService;

    /// <summary>
    /// Returns an array of Thoughts
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<List<Thought>> Get() =>
    await _thoughtService.GetAsync();

    /// <summary>
    /// Creates a Thought post.
    /// </summary>
    /// <param name="item"></param>
    /// <returns>Your created Thought</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /Thought
    ///     {
    ///        "id": 12432523523,
    ///        "body": "Why do we think at all?",
    ///        "author": "The thinker",
    ///        "title": "Thought of the day",
    ///        "tags": [
    ///        "deep thoughts"
    ///         ],
    ///        "comments": [
    ///          {
    ///             "body": "I wonder this to",
    ///             "email": "something@something.com",
    ///             "author": "Anna"
    ///             }
    ///         ],
    ///         "date": "2022-12-13T08:46:17.599Z"
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post(Thought newThought)
    {
        await _thoughtService.CreateAsync(newThought);
        return CreatedAtAction(nameof(Get), new { id = newThought.Id }, newThought);
    }

    /// <summary>
    /// Updates your Thought with matching Id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <response code="204">Returns the newly created item</response>
    /// <response code="400">If some of the fields are null</response>
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

    /// <summary>
    /// Deletes a specific Thought Post.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
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

    /// <summary>
    /// Adds a comment to a Thought of the matching id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Your created comment</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /Comment
    ///     {
    ///        "body": "This is my comment",
    ///        "email": "This is optional",
    ///        "author": "My name",
    ///     }
    ///
    /// </remarks>
    [HttpPatch("{id:length(24)}")]
    public async Task<IActionResult> AddCommentToThought(string id, [FromBody]Comment comment) {
        await _thoughtService.AddCommentAsync(id, comment);
        return NoContent();
    }

}