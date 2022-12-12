using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace grupp2.Models;

public class Planets {

     [BsonRepresentation(BsonType.ObjectId)]
     [BsonId]
    public ObjectId _id { get; set; }

    public string name { get; set; } = null!;

    public int orderFromSun {get; set;}

    public bool hasRings {get; set;}

     public List<string> mainAtmosphere {get; set;} = null!;

      [BsonElement("surfaceTemperatureC")]
    [JsonPropertyName("surfaceTemperatureC")]
    public SurfaceTemperatureC SurfaceTemperatureC {get; set;} = null!;

}
