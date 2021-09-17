using ApiSqlite.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiSqlite.Data
{
    public class SqlLiteDbContext : DbContext
    {
        public SqlLiteDbContext(DbContextOptions<SqlLiteDbContext> options)
            : base(options)
        {
        }

        public DbSet<First> Firsts => Set<First>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }
}