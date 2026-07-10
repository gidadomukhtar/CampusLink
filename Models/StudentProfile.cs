using System.ComponentModel.DataAnnotations;

namespace CampusLink.Models
{
    public class StudentProfile
    {
        public int Id { get; set; }

        public string UserId { get; set; } = string.Empty;

        [Required, StringLength(100)]
        public string FullName { get; set; } = string.Empty;

        [Required, StringLength(100)]
        public string University { get; set; } = string.Empty;

        [StringLength(100)]
        public string Department { get; set; } = string.Empty;

        [StringLength(500)]
        public string Bio { get; set; } = string.Empty;

        [StringLength(200)]
        public string Skills { get; set; } = string.Empty; // comma-separated: "C#, JavaScript, Flutter"

        [StringLength(200)]
        public string Interests { get; set; } = string.Empty; // comma-separated: "Web Dev, AI, Open Source"

        [StringLength(200)]
        public string? GitHubLink { get; set; }

        [StringLength(200)]
        public string? LinkedInLink { get; set; }

        [StringLength(50)]
        public string? ContactPhone { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        public DateTime DateUpdated { get; set; } = DateTime.UtcNow;
    }
}
