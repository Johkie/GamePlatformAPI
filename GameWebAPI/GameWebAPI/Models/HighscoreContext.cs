using Microsoft.EntityFrameworkCore;

namespace GameWebAPI.Models
{
    public class HighscoreContext : DbContext
    {
        public HighscoreContext(DbContextOptions<HighscoreContext> options) : base(options)
        {

        }

        public DbSet<HighscoreItem> HighscoreItems { get; set; }
    }
}
