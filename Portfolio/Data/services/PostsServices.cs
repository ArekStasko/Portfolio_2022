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

        public void InsertPost(string table, Post post)
        {
            var collection = _database.GetCollection<Post>(table);
            collection.InsertOne(post);
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

        public void DeletePost(string table, Guid Id)
        {
            var collection = _database.GetCollection<Post>(table);
            collection.DeleteOne(x => x._id.CompareTo(Id) == 0);
        }
    }
}
