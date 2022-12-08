using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace GRUPP2.Models;


public class Planets {

     [BsonRepresentation(BsonType.ObjectId)]
    public string? _id { get; set; }


    public string name { get; set; } = null!;

    public int orderFromSun {get; set;}

    public bool hasRings {get; set;}

     public List<string> mainAtmosphere {get; set;} = null!;
}
