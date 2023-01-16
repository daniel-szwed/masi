using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite("Filename=Uniterm.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public void Migrate()
        {
            Database.Migrate();
        }

        public virtual DbSet<Data> Data { get; set; }
        public virtual DbSet<Elimination> Eliminations { get; set; }
        public virtual DbSet<Sequence> Sequences { get; set; }
    }
}
