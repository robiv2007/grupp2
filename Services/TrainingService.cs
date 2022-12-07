using grupp2.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace grupp2.Services;

public class TrainingDBService {

    private readonly IMongoCollection<Training> _trainingCollection;

    public TrainingDBService(IOptions<MongoDBSettings> mongoDBSettings) {
        MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _trainingCollection = database.GetCollection<Training>(mongoDBSettings.Value.CollectionName);
    }

    public async Task<List<Training>> GetAsync() {     
        return await _trainingCollection.Find(new BsonDocument()).ToListAsync();
    }
    public async Task CreateAsync(Training training) { 
        await _trainingCollection.InsertOneAsync(training);
            return;
    }
    public async Task AddToTrainingAsync(string id, string movieId) {
    FilterDefinition<Training> filter = Builders<Training>.Filter.Eq("Id", id);
    UpdateDefinition<Training> update = Builders<Training>.Update.AddToSet<string>("movieIds", movieId);
    await _trainingCollection.UpdateOneAsync(filter, update);
    return;
    }
    public async Task DeleteAsync(string id) { 
        FilterDefinition<Training> filter = Builders<Training>.Filter.Eq("Id", id);
        await _trainingCollection.DeleteOneAsync(filter);
        return;

    }

}


