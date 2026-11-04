using Microsoft.AspNetCore.Identity;

namespace CampusLink.Models;

public class ApplicationUser : IdentityUser
{
    public string FullName { get; set; } = string.Empty;

    public string? University { get; set; }

    public string? Faculty { get; set; }

    public string? Department { get; set; }

    public string? Level { get; set; }
}