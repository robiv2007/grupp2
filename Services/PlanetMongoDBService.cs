using Grupp2.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;


namespace Grupp2.Services;

public class PlanetMongoDBService {

    private readonly IMongoCollection<Planets> _planetsCollection;

    public PlanetMongoDBService(IOptions<MongoDBSettings> mongoDBSettings) {
        MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _planetsCollection = database.GetCollection<Planets>(mongoDBSettings.Value.CollectionName);
    }

   
    public async Task CreateAsynk(Planets planets) {
        await _planetsCollection.InsertOneAsync(planets);
        return;
    }

    public async Task<List<Planets>> GetAsync() {
        return await _planetsCollection.Find(new BsonDocument()).ToListAsync();
    }

    public async Task AddToPlaylistAsync(string id, string planetId){
       FilterDefinition<Planets> filter = Builders<Planets>.Filter.Eq("id", id);
       UpdateDefinition<Planets> update = Builders<Planets>.Update.AddToSet<string>("planetId", planetId);
       await _planetsCollection.UpdateOneAsync(filter, update);
       return;
}

    public async Task DeleteAsync(string id){
        FilterDefinition<Planets> filter = Builders<Planets>.Filter.Eq("id", id);
        await _planetsCollection.DeleteOneAsync(filter);
        return;
    }

    public async Task UpdateAsync(ObjectId id, Planets updatedPlanet) =>
        await _planetsCollection.ReplaceOneAsync(x => x._id == id, updatedPlanet);
}