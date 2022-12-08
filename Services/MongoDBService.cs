using Grupp2.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Grupp2.Services;

public class MongoDBService {

    private readonly IMongoCollection<Sales> _salesCollection;

    public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings) {
        MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _salesCollection = database.GetCollection<Sales>(mongoDBSettings.Value.CollectionName);
    }

    public async Task<List<Sales>> GetAsync() {
        return await _salesCollection.Find(new BsonDocument()).ToListAsync();
     }

    public async Task CreateAsync(Sales sales) {
        await _salesCollection.InsertOneAsync(sales);
        return;
     }
    // public async Task AddToPlaylistAsync(string id, string salesId) {}
    // public async Task DeleteAsync(string id) { }

}