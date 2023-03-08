using Microsoft.EntityFrameworkCore;
using ProfileModels;

namespace ProjectApi.Context
{
    public class ProfileContext : DbContext
    {
        public ProfileContext(DbContextOptions<ProfileContext> options) : base(options)
        {
        }

        public DbSet<UserModel> UserModel { get; set; }
    }
}
