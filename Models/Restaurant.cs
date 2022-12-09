using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace GRUPP2.Models;

public class Restaurant {

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public ObjectId _id { get; set; }

    public string borough { get; set;} = null!;

    public string cuisine { get; set; } = null!;

    public List<string> menuItems { get; set; } = null!;

    [BsonElement("coordinates")]
    [JsonPropertyName("coordinates")]
    public Coordinates Coordinates {get; set;} = null!;

}