using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace Grupp2.Models;

public class Comment {

    public string body { get; set; } = null!;

    public string email { get; set; } = null!;

    public string author { get; set; } = null!;
}