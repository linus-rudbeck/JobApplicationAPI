using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using JobApplicationAPI.Models;

namespace JobApplicationAPI.Data
{
    public class JobApplicationContext(DbContextOptions options) : IdentityDbContext<IdentityUser>(options)
    {
        public DbSet<Job> Jobs { get; set; } = default!;
        public DbSet<Application> Applications { get; set; } = default!;
    }
}
