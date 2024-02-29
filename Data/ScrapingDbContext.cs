using Microsoft.EntityFrameworkCore;
using TopEdgeDemoProject.Models;

namespace TopEdgeDemoProject.Data
{
    public class ScrapingDbContext : DbContext
    {
        public ScrapingDbContext(DbContextOptions<ScrapingDbContext> options) : base(options) { }

        public DbSet<ScrapData> ScrapData { get; set; }
    }
}
