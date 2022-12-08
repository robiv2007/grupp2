using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace GRUPP2.Models;

public class Restaurant {

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public string username { get; set; } = null!;

    [BsonElement("")]
    [JsonPropertyName("")]
    public List<string> restaurantIds { get; set; } = null!;

}