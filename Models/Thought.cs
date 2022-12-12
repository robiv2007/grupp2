using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Grupp2.Models;

public class Thought 
{

[BsonId]
[BsonRepresentation(BsonType.ObjectId)]
public string? Id { get; set; }

public string Body { get; set; } = null!;

public string Author { get; set; } = null!;

public string Title { get; set; } = null!;

public List<string> Tags  { get; set; } = null!;

public List<Comment> Comments { get; set; } = null!;

public DateTime? Date { get; set; }
}