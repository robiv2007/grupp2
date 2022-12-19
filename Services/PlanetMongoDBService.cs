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
        //Create a MongoClient object to connect to the MongoDB server
        MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
        //Use the MongoClient to connect to the 'planets' database
        IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        //Use the database to access the 'planets' collection
        _planetsCollection = database.GetCollection<Planet>(mongoDBSettings.Value.CollectionName);
    }


//Task to create a new planet document with the type of planets
    public async Task CreateAsynk(Planet planet)
    {
        await _planetsCollection.InsertOneAsync(planet);
        return;
    }


//Task to display all the documents in the planets collection
    public async Task<List<Planet>> GetAsync()
    {
        //Find all the documents in the collection
        return await _planetsCollection.Find(new BsonDocument()).ToListAsync();
    }

//Task to update the selected planet based on the id and update or replace fields in the object
    public async Task UpdateAsync(string id, Planet updatedPlanet) =>
    await _planetsCollection.ReplaceOneAsync(x => x._Id == id, updatedPlanet);

//Task to find a planet in the collection that matches the entered Id
    public async Task<Planet?> GetAsync(string id) =>
        await _planetsCollection.Find(x => x._Id == id).FirstOrDefaultAsync();

//Task to delete a specific planet from the collection using a Id
    public async Task DeleteAsync(string id)
    {
        FilterDefinition<Planet> filter = Builders<Planet>.Filter.Eq("id", id);
        await _planetsCollection.DeleteOneAsync(filter);
        return;
    }

//Task that accepts one string id and is browsing the collection to find a
// match between the  entered Id and same id stored in the collection and to display it in the swagger UI
    public async Task<Planet?> GetOneById(string id) =>
await _planetsCollection.Find(x => x._Id == id).FirstOrDefaultAsync();

}
#pragma warning restore CS1591