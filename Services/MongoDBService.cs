using GRUPP2.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace GRUPP2.Services;

public class MongoDBService {

    private readonly IMongoCollection<Restaurant> _restaurantCollection;

    public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings) {
        MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _restaurantCollection = database.GetCollection<Restaurant>(mongoDBSettings.Value.CollectionName);
    }

    public async Task CreateAsync(Restaurant restaurant) {
        await _restaurantCollection.InsertOneAsync(restaurant);
        return;
    }

    public async Task<List<Restaurant>> GetAsync() {
        return await _restaurantCollection.Find(new BsonDocument()).ToListAsync();
    }

    public async Task AddToRestaurantAsync(string id, string restaurantId) {
        FilterDefinition<Restaurant> filter = Builders<Restaurant>.Filter.Eq("id", id);
        UpdateDefinition<Restaurant> update = Builders<Restaurant>.Update.AddToSet<string>("restaurantId", restaurantId);
        await _restaurantCollection.UpdateOneAsync(filter, update);
        return;
    }

    public async Task DeleteAsync(string id) {
        FilterDefinition<Restaurant> filter = Builders<Restaurant>.Filter.Eq("id", id);
        await _restaurantCollection.DeleteOneAsync(filter);
        return;
    }

}