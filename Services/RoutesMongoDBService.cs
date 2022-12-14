using Grupp2.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Grupp2.Services;

public class RoutesMongoDBService
{

    private readonly IMongoCollection<Routes> _routesCollection;

    public RoutesMongoDBService(IOptions<RoutesMongoDBSettings> mongoDBSettings)
    {
        MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _routesCollection = database.GetCollection<Routes>(mongoDBSettings.Value.CollectionName);
    }

    public async Task<List<Routes>> GetAsync()
    {
        return await _routesCollection.Find(new BsonDocument()).ToListAsync();
    }
    public async Task<Routes?> GetOneAsync(string id) =>
       await _routesCollection.Find(route => route.Id == id).FirstOrDefaultAsync();


    public async Task CreateAsync(Routes routes)
    {
        await _routesCollection.InsertOneAsync(routes);
        return;
    }

    public async Task ChangeAirplaneNameAsync(string id, string newairplanename)
    {
        FilterDefinition<Routes> filter = Builders<Routes>.Filter.Eq("Id", id);
        UpdateDefinition<Routes> update = Builders<Routes>.Update.Set<string>("airplane", newairplanename);
        await _routesCollection.UpdateOneAsync(filter, update);
        return;
    }



    public async Task DeleteAsync(string id)
    {
        FilterDefinition<Routes> filter = Builders<Routes>.Filter.Eq("Id", id);
        await _routesCollection.DeleteOneAsync(filter);
        return;
    }


    //     public async Task UpdateAsync(string id, Routes updatedRoute)
    //     {

    //          await _routesCollection.ReplaceOneAsync(route => route.Id == id, updatedRoute);

    //           await _routesCollection.ReplaceOneAsync(r => r.Id.Equals(id), 
    //     updatedRoute, new UpdateOptions { IsUpsert = true });

    //      await _routesCollection.ReplaceOneAsync(r => r.Id.Equals(id)
    //     , updatedRoute);

    //    await _routesCollection.ReplaceOneAsync(r => r.Id.Equals(id)
    //     , updatedRoute, new UpdateOptions { IsUpsert = true });


    //         await _routesCollection.FindOneAndReplaceAsync(
    //     Builders<Routes>.Filter.Eq(u => u.Id, id),
    //     updatedRoute,
    //     new FindOneAndReplaceOptions<Routes>
    //     { ReturnDocument = ReturnDocument.After });


    //     }

    public async Task UpdateAsync(string id, Routes updatedBook) =>
            await _routesCollection.ReplaceOneAsync(x => x.Id == id, updatedBook);

}