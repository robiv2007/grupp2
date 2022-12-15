using Grupp2.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Grupp2.Services;

#pragma warning disable CS1591
public class InspectionsDBService {

    private readonly IMongoCollection<Inspections> _inspectionsCollection;

    public InspectionsDBService(IOptions<InspectionDBSettings> inspectionDBSettings) {
        MongoClient client = new MongoClient(inspectionDBSettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(inspectionDBSettings.Value.DatabaseName);
        _inspectionsCollection = database.GetCollection<Inspections>(inspectionDBSettings.Value.CollectionName);
    }

    public async Task<List<Inspections>> GetAsync() {     
        return await _inspectionsCollection.Find(new BsonDocument()).ToListAsync();
    }

     public async Task<Inspections?> GetOneAsync(string id) =>
        await _inspectionsCollection.Find(x => x._Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Inspections inspections) { 
        await _inspectionsCollection.InsertOneAsync(inspections);
            return;
    }

    public async Task AddToInspectionsAsync(string id, string trainingId) {
    FilterDefinition<Inspections> filter = Builders<Inspections>.Filter.Eq("_Id", id);
    UpdateDefinition<Inspections> update = Builders<Inspections>.Update.AddToSet<string>("TrainingIds", trainingId);
    await _inspectionsCollection.UpdateOneAsync(filter, update);
    return;
    }

    public async Task DeleteAsync(string id) { 
        FilterDefinition<Inspections> filter = Builders<Inspections>.Filter.Eq("_Id", id);
        await _inspectionsCollection.DeleteOneAsync(filter);
        return;

    }
}
#pragma warning restore CS159


