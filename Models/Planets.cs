using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace Grupp2.Models;


#pragma warning disable CS1591
public class Planet
{

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? _Id { get; set; }

    public string name { get; set; } = null!;

    public int orderFromSun { get; set; }

    public bool hasRings { get; set; }

    public List<string> mainAtmosphere { get; set; } = null!;

    [BsonElement("surfaceTemperatureC")]
    [JsonPropertyName("surfaceTemperatureC")]
    public SurfaceTemperatureC SurfaceTemperatureC { get; set; } = null!;

}
#pragma warning restore CS1591
