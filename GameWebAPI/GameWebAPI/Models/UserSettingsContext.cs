using Microsoft.EntityFrameworkCore;

namespace GameWebAPI.Models
{
    public class UserSettingsContext : DbContext
    {
        public UserSettingsContext(DbContextOptions<UserSettingsContext> options) : base(options)
        {

        }

        public DbSet<UserSettings> UserSettings { get; set; }
    }
}
