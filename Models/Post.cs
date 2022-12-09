using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace Grupp2.Models;

public class Posts {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public string body { get; set; } = null!;

    public string permalink { get; set; } = null!;

    public string author { get; set; } = null!;

    public string title { get; set; } = null!;

    public List<string> tags { get; set; } = null!;

    public List<Comment> comments { get; set; } = null!;

    public DateTime? date { get; set; } 

}