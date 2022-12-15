using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace Grupp2.Models;

    /// <summary>
    /// Model for Restaurant document
    /// </summary>

public class Restaurant {

    /// <summary>
    /// Creates an unique id for each restaurant object
    /// </summary>

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? _id { get; set; }

    #pragma warning disable CS1591
    public string borough { get; set;} = null!;

    public string cuisine { get; set; } = null!;

    public List<string> menuItems { get; set; } = null!;

    /// <summary>
    /// referance for the database and model to communicate through
    /// </summary>
    [BsonElement("coordinates")]
    [JsonPropertyName("coordinates")]
    public Coordinates Coordinates {get; set;} = null!;

}

#pragma warning disable CS1591