using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Grupp2.Models;

public class Comment 
{
    [Required]
    public string Body { get; set; } = null!;

    [DefaultValue(null)]
    public string Email { get; set; } = null!;

    [Required]
    public string Author { get; set; } = null!;
}