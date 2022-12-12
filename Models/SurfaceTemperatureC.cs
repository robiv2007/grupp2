using MongoDB.Bson.Serialization.Attributes;

namespace Grupp2.Models;

public class SurfaceTemperatureC {


    [BsonElement("min")]
    public double? Min {get; set;}

    [BsonElement("max")]
    public double? Max {get; set;}

    [BsonElement("mean")]
    public double? Mean {get; set;}



}