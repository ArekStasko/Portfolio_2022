namespace Portfolio.Models
{
    public class PortfolioDatabaseSettings : IPortfolioDatabaseSettings
    {
        public string PostsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IPortfolioDatabaseSettings
    {
        string PostsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
