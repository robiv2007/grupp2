namespace grupp2.Models;

#pragma warning disable CS1591
public class MongoDBSettings {

    //Use this model to connect to database
    public string ConnectionURI { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;
    public string CollectionName { get; set; } = null!;

}
#pragma warning restore CS1591