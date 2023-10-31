using Core.Models;
using MongoDB.Bson.Serialization.Attributes;

namespace Core.Collections
{
    [BsonCollectionAttributeModel("BDProfileLevel")]
    public class BDProfileLevelCollection : DocumentModel
    {
        [BsonRequired]
        public string Name { get; set; } = null!;
        [BsonRequired]
        public UserCollection User { get; set; } = null!;
    }
}
