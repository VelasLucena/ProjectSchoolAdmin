using Microsoft.EntityFrameworkCore;
using SystemModels;

namespace ProjectApi.Context
{
    public class SystemContext : DbContext
    {
        public SystemContext(DbContextOptions<SystemContext> options) : base(options)
        {
        }

        public DbSet<Token> UserModel { get; set; }
    }
}

