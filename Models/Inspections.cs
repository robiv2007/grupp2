using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;
using System.Reflection;

namespace Grupp2.Models;

   /// <summary>
    /// Model for an Inspections document in collection
    /// </summary>
public class Inspections {

     /// <summary>
    /// Creates a unique id for each object
    /// </summary>
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? _Id { get; set; }

    /// <summary>
    /// BsonElement and JsonPropertyName is for the connection between database and model.
    /// saying that a document here called CertificateNumber will in the database be called certificate_number
    /// </summary>
    [BsonElement("certificate_number")]
    [JsonPropertyName("certificate_number")] 
    public int? CertificateNumber { get; set; } = null!;

     #pragma warning disable CS1591
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

    [BsonElement("training")]
    [JsonPropertyName("training")]
    public List<string> TrainingIds { get; set; } = null!;

}
#pragma warning restore CS1591

