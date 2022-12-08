using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;
using Grupp2.Models;
 
namespace Grupp2.Models;
 
public class Sales {
 
   
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public ObjectId? _id { get; set; }
 
    [BsonElement("saleDate")]
    [JsonPropertyName("saleDate")]
    public DateTime? SaleDate { get; set; }
 
    [BsonElement("items")]
    [JsonPropertyName("items")]
    public List<Item> Items { get; set; } = null!;
 
    [BsonElement("storeLocation")]
    [JsonPropertyName("storeLocation")]
    public string StoreLocation { get; set; } = null!;
 
    [BsonElement("customer")]
    [JsonPropertyName("customer")]
    public Customer Customer { get; set; } = null!;
 
    [BsonElement("couponUsed")]
    [JsonPropertyName("couponUsed")]
    public bool CouponUsed { get; set; } = false;
 
 
    [BsonElement("purchaseMethod")]
    [JsonPropertyName("purchaseMethod")]
    public string PurchaseMethod { get; set; } = null!;
   
 
}
