using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace Grupp2.Models;

public class Transaction
{


    // [BsonElement("date")]
    // [JsonPropertyName("date")]
    public DateTime date { get; set; }

    // [BsonElement("amount")]
    // [JsonPropertyName("amount")]
    public int amount { get; set; }

    // [BsonElement("transaction_code")]
    // [JsonPropertyName("transaction_code")]
    public string? transaction_code { get; set; }

    // [BsonElement("symbol")]
    // [JsonPropertyName("symbol")]
    public string? symbol { get; set; }

    // [BsonElement("price")]
    // [JsonPropertyName("price")]
    public string? price { get; set; }

    // [BsonElement("total")]
    // [JsonPropertyName("total")]
    public string? total { get; set; }



}