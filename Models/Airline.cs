using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace Grupp2.Models;

//[BsonIgnoreExtraElements]
public class Airline
{
    [BsonElement("id")]
    [JsonPropertyName("id")]
    public int ID { get; set; }

    [BsonElement("name")]
    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;

#pragma warning disable CS1591

    [BsonElement("alias")]
    [JsonPropertyName("aias")]
    public string Alias { get; set; } = null!;

    [BsonElement("iata")]
    [JsonPropertyName("iata")]
    public string Iata { get; set; } = null!;


}
#pragma warning disable CS1591