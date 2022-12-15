// Tell the program in what folder the file can be found
namespace Grupp2.Models;

#pragma warning disable CS1591
// Create a object that have 3 parameters to connect with the database
public class ThoughtsDatabaseSettings
{
    public string ConnectionURI { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string CollectionName { get; set; } = null!;
}
#pragma warning restore CS1591