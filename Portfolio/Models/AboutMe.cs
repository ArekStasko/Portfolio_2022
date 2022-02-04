using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Portfolio.Models
{
    public class AboutMe
    {
        [BsonId]
        public Guid _id { get; set; }

        [BsonElement("Name")]
        public string Title { get; set; } = "None";
        public string AboutDescription { get; set; } = "None Description";
        public string AboutSkills { get; set; } = "None Description";
        public string PhotoLink { get; set; }
    }
}
