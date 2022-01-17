using MongoDB.Driver;
using MongoDB.Bson;
using Portfolio.Models;

namespace Portfolio.Data.services
{
    public class PostsServices
    {
        private IMongoDatabase _database;

        public PostsServices(string db)
        {
            var client = new MongoClient();
            _database = client.GetDatabase(db);
            Console.WriteLine($"Connected :  {_database.Client}");
        }

        /*
        public void InsertPost<Post>(string table, Post post)
        {
            var collection = _database.GetCollection<Post>(table);
            collection.InsertOne(post);
        }
        */
    }
}
