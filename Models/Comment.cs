using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Grupp2.Models;

public class Comment 
{
    public string Body { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Author { get; set; } = null!;
}