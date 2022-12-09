using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace grupp2.Models;

    //Creates a customized class with different properties that can be used in the head model
public class Address {

    [BsonElement("city")]
    [JsonPropertyName("city")]
    public string? City { get; set; }

    [BsonElement("zip")]
    [JsonPropertyName("zip")]
    public int Zip { get; set; }

     [BsonElement("street")]
    [JsonPropertyName("street")]
    public string? Street { get; set; }

     [BsonElement("number")]
    [JsonPropertyName("number")]
    public int Number { get; set; }

}