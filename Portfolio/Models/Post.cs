using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Portfolio.Models
{
    public class Post
    {
        [BsonId]
        public Guid _id { get; set; }

        [BsonElement("Name")]
        public string Title { get; set; } = "None";
        public string GithubLink { get; set; } = String.Empty;
        public string SummaryDescription { get; set; } = "None Description";
        public string PhotoLink { get; set; } = String.Empty;
        public string VideoLink { get; set; } = String.Empty;
        public string Description { get; set; } = "None Description";
    }
}
