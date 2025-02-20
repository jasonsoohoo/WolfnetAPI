using Microsoft.EntityFrameworkCore;
using WolfnetAPI.Models;

namespace WolfnetAPI.Data
{
    public class MatchDbContext : DbContext
    {
        public MatchDbContext(DbContextOptions<MatchDbContext> options) : base(options)
        {
            // Intentionally Empty
        }

        public DbSet<Match> Matches { get; set; }
    }
}
