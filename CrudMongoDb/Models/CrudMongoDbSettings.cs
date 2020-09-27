namespace CrudMongoDb.Models
{
    public class CrudMongoDbSettings : ICrudMongoDbSettings
    {
        public string CrudCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface ICrudMongoDbSettings
    {
        string CrudCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
