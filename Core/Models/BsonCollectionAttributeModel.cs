namespace Core.Models
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class BsonCollectionAttributeModel : Attribute
    {
        public string CollectionName { get; }

        public BsonCollectionAttributeModel(string collectionName)
        {
            CollectionName = collectionName;
        }
    }
}
