using Grupp2.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Grupp2.Services;

#pragma warning disable CS1591
public class InspectionsDBService {

    private readonly IMongoCollection<Inspections> _inspectionsCollection;

    //Connect the client with their chosen collection and/or document in database
    public InspectionsDBService(IOptions<MongoDBSettings> mongoDBSettings) {
        MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _inspectionsCollection = database.GetCollection<Inspections>(mongoDBSettings.Value.CollectionName);
    }

    //Get all documents from a collection stored in database
    public async Task<List<Inspections>> GetAsync() {     
        return await _inspectionsCollection.Find(new BsonDocument()).ToListAsync();
    }

    //Get a certain item, based on id, from list of inspection items 
     public async Task<Inspections?> GetOneAsync(string id) =>
        await _inspectionsCollection.Find(x => x._Id == id).FirstOrDefaultAsync();

    //Create a new document to collection
    public async Task CreateAsync(Inspections inspections) { 
        await _inspectionsCollection.InsertOneAsync(inspections);
            return;
    }

    //Find document by id and add new training item to list
    public async Task AddToInspectionsAsync(string id, string trainingId) {
    FilterDefinition<Inspections> filter = Builders<Inspections>.Filter.Eq("_Id", id);
    UpdateDefinition<Inspections> update = Builders<Inspections>.Update.AddToSet<string>("TrainingIds", trainingId);
    await _inspectionsCollection.UpdateOneAsync(filter, update);
    return;
    }

    //Find and delete document by id 
    public async Task DeleteAsync(string id) { 
        FilterDefinition<Inspections> filter = Builders<Inspections>.Filter.Eq("_Id", id);
        await _inspectionsCollection.DeleteOneAsync(filter);
        return;

    }
}
#pragma warning restore CS159


