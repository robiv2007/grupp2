// Import libraries from Mongodb and system for more functionality
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Grupp2.Models;

#pragma warning disable CS1591
// This class represents a Thought post.
public class Thought 
{
// The id will be automaticly generated for us with help from our Bson import
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