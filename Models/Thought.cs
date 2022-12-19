// Import libraries from Mongodb and system for more functionality
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Grupp2.Models;

#pragma warning disable CS1591
// This class represents a Thought post.
public class Thought 
{
/// <summary>Uniqe id for our Thought that will be generated for us by Bson</summary>
[BsonId]
[BsonRepresentation(BsonType.ObjectId)]
public string? Id { get; set; }

[Required]
public string Body { get; set; } = null!;

/// <summary>The author of the Thought post</summary>
[Required]
public string Author { get; set; } = null!;

[Required]
public string Title { get; set; } = null!;

/// <summary>Tags for each Thought post to make search easier</summary>
[Required]
public List<string> Tags  { get; set; } = null!;


public List<Comment> Comments { get; set; } = null!;

[Required]
public DateTime? Date { get; set; }
}

#pragma warning restore CS1591