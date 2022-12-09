using Grupp2.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Grupp2.Services;

public class PostMongoDBService {

    private readonly IMongoCollection<Posts> _postsCollection;

    public PostMongoDBService(IOptions<MongoDBSettings> mongoDBSettings) {
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
    public async Task AddToPlaylistAsync(string id, Comment comment) {
        FilterDefinition<Posts> filter = Builders<Posts>.Filter.Eq("Id", id);
        UpdateDefinition<Posts> update = Builders<Posts>.Update.AddToSet<Comment>("comments", comment);
        await _postsCollection.UpdateOneAsync(filter, update);
        return;

    }
    public async Task DeleteAsync(string id) { 
        FilterDefinition<Posts> filter = Builders<Posts>.Filter.Eq("Id", id);
        await _postsCollection.DeleteOneAsync(filter);
        return;
    }

}