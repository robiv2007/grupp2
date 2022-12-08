using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;
 
namespace Grupp2.Models;
 
public class Item {
   
    [BsonElement("name")]
    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;
 
    [BsonElement("tags")]
    [JsonPropertyName("tags")]
    public List<string> Tags { get; set; } = null!;
 
    [BsonElement("price")]
    [JsonPropertyName("price")]
    public decimal? Price { get; set; }
 
    [BsonElement("quantity")]
    [JsonPropertyName("quantity")]
    public int? Quantity { get; set; }
   
}
