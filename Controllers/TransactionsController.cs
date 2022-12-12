using System;
using Microsoft.AspNetCore.Mvc;
using Grupp2.Services;
using Grupp2.Models;

namespace Grupp2.Controllers;

[Controller]
[Route("api/[controller]")]
[Produces("application/json")]
public class TransactionsController : Controller
{

    private readonly TransactionsMongoDBService _mongoDBService;

    public TransactionsController(TransactionsMongoDBService mongoDBService)
    {
        _mongoDBService = mongoDBService;
    }



    [HttpGet]
    public async Task<List<Transactions>> Get()
    {
        return await _mongoDBService.GetAsync();
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Transactions transactions)
    {
        await _mongoDBService.CreateAsynk(transactions);
        return CreatedAtAction(nameof(Get), new { id = transactions._id }, transactions);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AddToTransactions(string id, [FromBody] string transactionId)
    {
        await _mongoDBService.AddToTransactionsAsync(id, transactionId);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await _mongoDBService.DeleteAsync(id);
        return NoContent();
    }

}