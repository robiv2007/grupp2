using MongoDB.Bson.Serialization.Attributes;

namespace GRUPP2.Models;

public class SurfaceTemperatureC {


    [BsonElement("min")]
    public int Min {get; set;}

    [BsonElement("max")]
    public int Max {get; set;}

    [BsonElement("mean")]
    public int Mean {get; set;}



}