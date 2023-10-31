using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Core.Interfaces
{
    public interface IDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        ObjectId Id { get; set; }

        DateTime CreatedAt { get; }        

        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        [BsonIgnoreIfNull]
        DateTime? UpdatedAt { get; set; }

        [BsonRequired]
        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }
    }
}
