using Microsoft.EntityFrameworkCore;

namespace UrlShortner.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Models.Url> urls { get; set; }
    }
}
