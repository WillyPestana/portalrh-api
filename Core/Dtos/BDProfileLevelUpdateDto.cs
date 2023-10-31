using System.ComponentModel.DataAnnotations;
namespace Core.Dtos
{
    public class BDProfileLevelUpdateDto
    {
        [Required]
        public string Id { get; set; } = null!;
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public UserCollectionDto User { get; set; } = null!;
    }
}
