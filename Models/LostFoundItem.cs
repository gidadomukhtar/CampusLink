using System.ComponentModel.DataAnnotations;

namespace CampusLink.Models
{
    public enum ItemStatus
    {
        Lost,
        Found,
        Resolved,
    }

    public class LostFoundItem
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Title { get; set; } = string.Empty;

        [Required, StringLength(1000)]
        public string Description { get; set; } = string.Empty;

        [Required]
        public ItemStatus Status { get; set; }

        [StringLength(100)]
        public string? Category { get; set; }

        [StringLength(200)]
        public string? Location { get; set; }

        public DateTime DatePosted { get; set; } = DateTime.UtcNow;

        public string PostedByUserId { get; set; } = string.Empty;

        [StringLength(100)]
        public string? PostedByName { get; set; }

        [StringLength(50)]
        public string? ContactInfo { get; set; }
    }
}
