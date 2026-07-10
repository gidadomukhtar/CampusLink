using CampusLink.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CampusLink.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<LostFoundItem> LostFoundItems { get; set; }
    public DbSet<StudentProfile> StudentProfiles { get; set; }
}
