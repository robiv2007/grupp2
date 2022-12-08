using Grupp2.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Grupp2.Services;

public class MongoDBService {

    private readonly IMongoCollection<Posts> _postsCollection;

    public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings) {
        MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _postsCollection = database.GetCollection<Posts>(mongoDBSettings.Value.CollectionName);
    }

    public async Task<List<Posts>> GetAsync() {
        return await _postsCollection.Find(new BsonDocument()).ToListAsync();
     }

    public async Task CreateAsync(Posts posts) {
        await _postsCollection.InsertOneAsync(posts);
        return;
     }
    // public async Task AddToPlaylistAsync(string id, string salesId) {}
    // public async Task DeleteAsync(string id) { }

}