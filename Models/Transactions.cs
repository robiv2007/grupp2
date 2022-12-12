using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace Grupp2.Models;

public class Transactions
{

    [BsonRepresentation(BsonType.ObjectId)]
    [BsonId]
    public ObjectId _id { get; set; }

    // [BsonElement("account_id")]
    // [JsonPropertyName("account_id")]
    public int account_id { get; set; }

    // [BsonElement("transaction_count")]
    // [JsonPropertyName("transaction_count")]
    public int transaction_count { get; set; }

    // [BsonElement("bucket_start_date")]
    // [JsonPropertyName("bucket_start_date")]
    public DateTime bucket_start_date { get; set; }

    // [BsonElement("bucket_end_date")]
    // [JsonPropertyName("bucket_end_date")]
    public DateTime bucket_end_date { get; set; }

    // [BsonElement("transactions")]
    // [JsonPropertyName("transactions")]
    public List<Transaction> transactions { get; set; } = null!;



}