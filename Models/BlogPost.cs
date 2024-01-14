using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace blog_bakend.Models
{
    public class BlogPost
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("BlogTitle")]
        public string? Title { get; set; }

        [BsonElement("BlogContent")]
        public string? Description { get; set; }

        [BsonElement("BlogImages")]
        public List<byte[]>? BlogImages { get; set; }

        [BsonElement("Author")]
        public string? Author { get; set; }

        [BsonElement("CreatedDate")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
