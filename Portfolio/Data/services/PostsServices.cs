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

        public List<Post> GetPosts(string table)
        {
            var collection = _database.GetCollection<Post>(table);
            return collection.Find(new BsonDocument()).ToList();
        }

        public Post GetPostByID(string table, Guid Id)
        {
            var collection = _database.GetCollection<Post>(table);
            var filter = Builders<Post>.Filter.Eq("_id", Id);

            return collection.Find(filter).First();
        }

    }
}
