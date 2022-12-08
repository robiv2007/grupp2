using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;
 
namespace Grupp2.Models;
 
public class Customer {
   
    [BsonElement("gender")]
    [JsonPropertyName("gender")]
    public string Gender { get; set; } = null!;
 
    [BsonElement("age")]
    [JsonPropertyName("age")]
    public int? Age { get; set; }
 
    [BsonElement("email")]
    [JsonPropertyName("email")]
    public string Email { get; set; } = null!;
 
    [BsonElement("satisfaction")]
    [JsonPropertyName("satisfaction")]
    public int? Satisfaction { get; set; }
 
   
   
}
