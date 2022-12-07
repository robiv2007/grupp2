using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;
using System.Reflection;

namespace grupp2.Models;

public class Training {

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? _Id { get; set; }

   [BsonElement("id")]
   [JsonPropertyName("id")] 
    public string? Id { get; set; } = null!;

    [BsonElement("certificate_number")]
   [JsonPropertyName("certificate_number")] 
    public int? CertificateNumber { get; set; } = null!;

     [BsonElement("business_name")]
   [JsonPropertyName("business_name")] 
    public string? BusinessName { get; set; } = null!;

    [BsonElement("date")]
   [JsonPropertyName("date")] 
    public string? Date { get; set; } = null!;

    [BsonElement("result")]
   [JsonPropertyName("result")] 
    public string? Result { get; set; } = null!;

    [BsonElement("sector")]
   [JsonPropertyName("sector")] 
    public string? Sector { get; set; } = null!;

     [BsonElement("address")]
    [JsonPropertyName("address")]
    public Address? Address { get; set; } = null!;

}

