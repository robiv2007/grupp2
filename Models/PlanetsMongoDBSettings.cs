namespace Grupp2.Models;

#pragma warning disable CS1591
public class PlanetsMongoDBSettings
{

    /// <summary>
    /// The connection URL for the MongoDB database.
    /// </summary>
    public string ConnectionURI { get; set; } = null!;

    /// <summary>
    /// The name of the database containing planet data.
    /// </summary>
    public string DatabaseName { get; set; } = null!;

    /// <summary>
    /// The name of the collection containing planet data.
    /// </summary>
    public string CollectionName { get; set; } = null!;
}
#pragma warning restore CS1591