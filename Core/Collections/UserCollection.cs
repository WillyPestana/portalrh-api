using Core.Models;

namespace Core.Collections
{
    [BsonCollectionAttributeModel("User")]
    public class UserCollection : DocumentModel
    {
        public string UserId { get; set; } = null!;

        public string DisplayName { get; set; } = null!;

        public string GivenName { get; set; } = null!;    

        public string Mail { get; set; } = null!;

        public string MobilePhone { get; set; } = null!;

        public string Surname { get; set; } = null!;

        public string UserPrincipalName { get; set; } = null!;

        public string Photo { get; set; } = null!;
    }
}
