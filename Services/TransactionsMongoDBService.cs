using Grupp2.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Grupp2.Services;

public class TransactionsMongoDBService
{

    private readonly IMongoCollection<Transactions> _transactionCollection;

    public TransactionsMongoDBService(IOptions<MongoDBSettings> mongoDBSettings)
    {
        MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _transactionCollection = database.GetCollection<Transactions>(mongoDBSettings.Value.CollectionName);
    }


    public async Task CreateAsynk(Transactions transactions)
    {
        await _transactionCollection.InsertOneAsync(transactions);
        return;
    }

    public async Task<List<Transactions>> GetAsync()
    {
        return await _transactionCollection.Find(new BsonDocument()).ToListAsync();
    }

    public async Task AddToTransactionsAsync(string id, string transactionId)
    {
        FilterDefinition<Transactions> filter = Builders<Transactions>.Filter.Eq("_id", id);
        UpdateDefinition<Transactions> update = Builders<Transactions>.Update.AddToSet<string>("transactionId", transactionId);
        await _transactionCollection.UpdateOneAsync(filter, update);
        return;
    }

    public async Task DeleteAsync(string id)
    {
        FilterDefinition<Transactions> filter = Builders<Transactions>.Filter.Eq("_Id", id);
        await _transactionCollection.DeleteOneAsync(filter);
        return;
    }
}