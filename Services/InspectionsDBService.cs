using grupp2.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace grupp2.Services;

public class InspectionsDBService {

    private readonly IMongoCollection<Inspections> _inspectionsCollection;

    //Connect the client with their chosen collection and/or document in database
    public InspectionsDBService(IOptions<MongoDBSettings> mongoDBSettings) {
        MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _inspectionsCollection = database.GetCollection<Inspections>(mongoDBSettings.Value.CollectionName);
    }

    //Asyncronically gets all documents from a collection stored in database
    public async Task<List<Inspections>> GetAsync() {     
        return await _inspectionsCollection.Find(new BsonDocument()).ToListAsync();
    }

    //Asyncronically creates a new document to collection
    public async Task CreateAsync(Inspections inspections) { 
        await _inspectionsCollection.InsertOneAsync(inspections);
            return;
    }

    //Asyncronically finds document by id and then adds new training item to list
    public async Task AddToInspectionsAsync(string id, string trainingId) {
    FilterDefinition<Inspections> filter = Builders<Inspections>.Filter.Eq("_Id", id);
    UpdateDefinition<Inspections> update = Builders<Inspections>.Update.AddToSet<string>("TrainingIds", trainingId);
    await _inspectionsCollection.UpdateOneAsync(filter, update);
    return;
    }

    //Asyncronically finds document by id and deletes it
    public async Task DeleteAsync(string id) { 
        FilterDefinition<Inspections> filter = Builders<Inspections>.Filter.Eq("_Id", id);
        await _inspectionsCollection.DeleteOneAsync(filter);
        return;

    }

}


