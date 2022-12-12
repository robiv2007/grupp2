using Grupp2.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Grupp2.Services;

public class ThoughtService
{
    private readonly IMongoCollection<Thought> _thoughtsCollection;

    public ThoughtService(
        IOptions<ThoughtsDatabaseSettings> thoughDatabaseSetting)
        {
            var mongoClient = new MongoClient(
                thoughDatabaseSetting.Value.ConnectionString
            );

            var mongoDatabase = mongoClient.GetDatabase(
                thoughDatabaseSetting.Value.CollectionName
            );

            _thoughtsCollection = mongoDatabase.GetCollection<Thought>(
                thoughDatabaseSetting.Value.CollectionName
            );
        }

        public async Task<List<Thought>> GetAsync() => 
        await _thoughtsCollection.Find(_ => true).ToListAsync();

        public async Task CreateAsync(Thought newThought) =>
        await _thoughtsCollection.InsertOneAsync(newThought);
}