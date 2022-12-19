// import annotations to use the [required] function
using System.ComponentModel.DataAnnotations;

namespace Grupp2.Models;

#pragma warning disable CS1591
// This class is a single comment that can be made and added to the comments list on a Thought
public class Comment 
{
    [Required]
    public string Body { get; set; } = null!;

    /// <summary>Email to the author of the comment, this can be left empty</summary>
    public string Email { get; set; } = string.Empty;

    [Required]
    public string Author { get; set; } = null!;
}
#pragma warning restore CS1591