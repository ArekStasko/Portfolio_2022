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
        }

        public void InsertPost<Post>(string table, Post post)
        {
            var collection = _database.GetCollection<Post>(table);
            collection.InsertOne(post);
        }

        public List<Post> GetPosts<Post>(string table)
        {
            var collection = _database.GetCollection<Post>(table);
            return collection.Find(new BsonDocument()).ToList();
        }
    }
}
