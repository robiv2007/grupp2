using MongoDB.Bson.Serialization.Attributes;

namespace Grupp2.Models;

public class Coordinates {

    [BsonElement("long")]
    public double? Long { get; set;}

    [BsonElement("lat")]
    public double? Lat { get; set; }

}