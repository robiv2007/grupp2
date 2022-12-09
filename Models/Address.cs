using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace grupp2.Models;

    //Creates a customized class with different properties that can be used in the head model

    /// <summary>
    /// Address model containing properties of city, zip, street and number
    /// </summary>
public class Address {

    [BsonElement("city")]
    [JsonPropertyName("city")]

    #pragma warning disable CS1591
    public string? City { get; set; }

    [BsonElement("zip")]
    [JsonPropertyName("zip")]
    public int Zip { get; set; }

     [BsonElement("street")]
    [JsonPropertyName("street")]
    public string? Street { get; set; }

     [BsonElement("number")]
    [JsonPropertyName("number")]
    public int Number { get; set; }

}
    #pragma warning restore CS1591