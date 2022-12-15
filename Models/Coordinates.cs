using MongoDB.Bson.Serialization.Attributes;

namespace Grupp2.Models;

#pragma warning disable CS1591
public class Coordinates {

    [BsonElement("long")]
    public double? Long { get; set;}

    [BsonElement("lat")]
    public double? Lat { get; set; }

}

#pragma warning disable CS1591