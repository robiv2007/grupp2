
using System.ComponentModel.DataAnnotations;

namespace Grupp2.Models;

#pragma warning disable CS1591
public class Comment 
{
    [Required]
    public string Body { get; set; } = null!;

    public string Email { get; set; } = string.Empty;

    [Required]
    public string Author { get; set; } = null!;
}
#pragma warning restore CS1591