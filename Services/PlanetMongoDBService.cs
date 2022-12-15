using Grupp2.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;


namespace Grupp2.Services;

#pragma warning disable CS1591
public class PlanetMongoDBService
{

    private readonly IMongoCollection<Planet> _planetsCollection;

    public PlanetMongoDBService(IOptions<PlanetsMongoDBSettings> mongoDBSettings)
    {
        MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _planetsCollection = database.GetCollection<Planet>(mongoDBSettings.Value.CollectionName);
    }


    public async Task CreateAsynk(Planet planets)
    {
        await _planetsCollection.InsertOneAsync(planets);
        return;
    }


    public async Task<List<Planet>> GetAsync()
    {
        return await _planetsCollection.Find(new BsonDocument()).ToListAsync();
    }


    public async Task AddToPlaylistAsync(string id, string planetId)
    {
        FilterDefinition<Planet> filter = Builders<Planet>.Filter.Eq("id", id);
        UpdateDefinition<Planet> update = Builders<Planet>.Update.AddToSet<string>("planetId", planetId);
        await _planetsCollection.UpdateOneAsync(filter, update);
        return;
    }

    public async Task DeleteAsync(string id)
    {
        FilterDefinition<Planet> filter = Builders<Planet>.Filter.Eq("id", id);
        await _planetsCollection.DeleteOneAsync(filter);
        return;
    }

    public async Task<Planet?> GetOneById(string id) =>
await _planetsCollection.Find(x => x._Id == id).FirstOrDefaultAsync();

}
#pragma warning restore CS1591