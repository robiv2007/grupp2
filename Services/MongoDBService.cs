using grupp2.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace grupp2.Services;

public class MongoDBService {

    private readonly IMongoCollection<Inspections> _inspectionsCollection;

    public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings) {
        MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _inspectionsCollection = database.GetCollection<Inspections>(mongoDBSettings.Value.CollectionName);
    }

    public async Task<List<Inspections>> GetAsync() {     
        return await _inspectionsCollection.Find(new BsonDocument()).ToListAsync();
    }
    public async Task CreateAsync(Inspections inspections) { 
        await _inspectionsCollection.InsertOneAsync(inspections);
            return;
    }
    public async Task AddToInspectionsAsync(string id, string inspectionsId) {
    FilterDefinition<Inspections> filter = Builders<Inspections>.Filter.Eq("Id", id);
    UpdateDefinition<Inspections> update = Builders<Inspections>.Update.AddToSet<string>("inspectionsId", inspectionsId);
    await _inspectionsCollection.UpdateOneAsync(filter, update);
    return;
    }
    public async Task DeleteAsync(string id) { 
        FilterDefinition<Inspections> filter = Builders<Inspections>.Filter.Eq("Id", id);
        await _inspectionsCollection.DeleteOneAsync(filter);
        return;

    }

}


