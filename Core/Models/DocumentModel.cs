using Core.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace Core.Models
{
    public abstract class DocumentModel : IDocument
    {      
        public ObjectId Id { get; set; }

        public DateTime CreatedAt => Id.CreationTime;               

        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        [BsonIgnoreIfNull]
        public DateTime? UpdatedAt { get; set; }

        public void SetUpdatedAt()
        {
            UpdatedAt = DateTime.UtcNow;
        }

        [BsonRequired]
        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public void SetDeleted()
        {
            IsDeleted = true;
        }
    }
}
