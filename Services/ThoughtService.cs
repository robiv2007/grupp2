using Grupp2.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Grupp2.Services;

#pragma warning disable CS1591
// Create a service to move some of the code from the controller and avoid to much code in on place and make it more safe
public class ThoughtService
{
    // Create a private collection of type Thought
    private readonly IMongoCollection<Thought> _thoughtsCollection;

    // Create a public thoughtservice
    public ThoughtService(
        // When created inject with thoughtDatabaseSetting to access uri, database and collection to get data from
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

        // Get an array of thoughts from the database
        public async Task<List<Thought>> GetAsync() => 
        await _thoughtsCollection.Find(_ => true).ToListAsync();

        //  Get a specific Thought object from the database using the id
        public async Task<Thought?> GetAsync(string id) =>
        await _thoughtsCollection.Find(thought => thought.Id == id).FirstOrDefaultAsync();

        // Create a new Thought and add it to the database
        public async Task CreateAsync(Thought newThought) =>
        await _thoughtsCollection.InsertOneAsync(newThought);

        // Find a Thought in the database and replace the object with a new one
        public async Task UpdateAsync(string id, Thought updatedThought) =>
        await _thoughtsCollection.ReplaceOneAsync(thought => thought.Id == id, updatedThought);

        public async Task DeleteAsync(string id) =>
        await _thoughtsCollection.DeleteOneAsync(thought => thought.Id == id);

        // Find a Thought in the database and add a comment to the array of comments
        public async Task AddCommentAsync(string thoughtId, Comment newComment) {
            FilterDefinition<Thought> filter = Builders<Thought>.Filter.Eq("Id", thoughtId);
            UpdateDefinition<Thought> update = Builders<Thought>.Update.AddToSet<Comment>("Comments", newComment);
            await _thoughtsCollection.UpdateOneAsync(filter, update);
            return;
        }
}
#pragma warning restore CS1591