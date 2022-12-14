using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Grupp2.Models;

#pragma warning disable CS1591
public class Thought 
{

[BsonId]
[BsonRepresentation(BsonType.ObjectId)]
public string? Id { get; set; }

[Required]
public string Body { get; set; } = null!;

[Required]
public string Author { get; set; } = null!;

[Required]
public string Title { get; set; } = null!;

[Required]
public List<string> Tags  { get; set; } = null!;


public List<Comment> Comments { get; set; } = null!;

[Required]
public DateTime? Date { get; set; }
}

#pragma warning restore CS1591