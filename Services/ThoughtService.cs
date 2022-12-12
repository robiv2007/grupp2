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
                thoughDatabaseSetting.Value.ConnectionURI
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

        public async Task<Thought?> GetAsync(string id) =>
        await _thoughtsCollection.Find(thought => thought.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Thought newThought) =>
        await _thoughtsCollection.InsertOneAsync(newThought);

        // public async Task UpdateAsync(string id, Thought updatedThought) =>
        // await _thoughtsCollection.ReplaceOneAsync(thought => thought.Id == id, updatedThought);

        public async Task DeleteAsync(string id) =>
        await _thoughtsCollection.DeleteOneAsync(thought => thought.Id == id);

        public async Task AddCommentAsync(string thoughtId, Comment newComment) {
            FilterDefinition<Thought> filter = Builders<Thought>.Filter.Eq("Id", thoughtId);
            UpdateDefinition<Thought> update = Builders<Thought>.Update.AddToSet<Comment>("Comments", newComment);
            await _thoughtsCollection.UpdateOneAsync(filter, update);
            return;
        }
}