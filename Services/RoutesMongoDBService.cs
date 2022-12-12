using Grupp2.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Grupp2.Services;

public class RoutesMongoDBService
{

    private readonly IMongoCollection<Routes> _routesCollection;

    public RoutesMongoDBService(IOptions<MongoDBSettings> mongoDBSettings)
    {
        MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _routesCollection = database.GetCollection<Routes>(mongoDBSettings.Value.CollectionName);
    }

    public async Task<List<Routes>> GetAsync()
    {
        return await _routesCollection.Find(new BsonDocument()).ToListAsync();
    }

    public async Task CreateAsync(Routes routes)
    {
        await _routesCollection.InsertOneAsync(routes);
        return;
    }

    public async Task AddToRoutesAsync(string id, string routesId)
    {
        FilterDefinition<Routes> filter = Builders<Routes>.Filter.Eq("_id", id);
        UpdateDefinition<Routes> update = Builders<Routes>.Update.AddToSet<string>("routesId", routesId);
        await _routesCollection.UpdateOneAsync(filter, update);
        return;
    }

    public async Task DeleteAsync(string id)
    {
        FilterDefinition<Routes> filter = Builders<Routes>.Filter.Eq("_id", id);
        await _routesCollection.DeleteOneAsync(filter);
        return;
    }
}