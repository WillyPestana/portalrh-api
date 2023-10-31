namespace Core.Dtos
{
    public class BDProfileLevelDto
    {
        public string Id { get; set; } = null!;   
        public string Name { get; set; } = null!;
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }       
        public DateTime? UpdatedAt { get; set; }
        public UserCollectionDto User { get; set; } = null!;
    }
}
