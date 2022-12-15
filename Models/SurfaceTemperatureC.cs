using MongoDB.Bson.Serialization.Attributes;

namespace Grupp2.Models;

#pragma warning disable CS1591
public class SurfaceTemperatureC
{


    [BsonElement("min")]
    public double? Min { get; set; }

    [BsonElement("max")]
    public double? Max { get; set; }

    [BsonElement("mean")]
    public double? Mean { get; set; }

}
#pragma warning restore CS1591