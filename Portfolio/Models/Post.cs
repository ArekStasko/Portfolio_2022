using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Portfolio.Models
{
    public class Post
    {
        [BsonId]
        public Guid Id { get; set; }

        [BsonElement("Name")]
        public string Title { get; set; }
        public string SummaryDescription { get; set; }
        public string Description { get; set; }
        public string PhotoLink { get; set; }
        public string VideoLink { get; set; }

    }
}
