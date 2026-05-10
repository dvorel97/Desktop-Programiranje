using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace Projekt.DB
{
    public class NoteContext : DbContext
    {
        public DbSet<NoteEntity> Notes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            string connectionString = ConfigurationManager
                .ConnectionStrings["NoteForgeDB"]
                .ConnectionString;

            options.UseOracle(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NoteEntity>()
                .Property(n => n.Id)
                .HasColumnType("VARCHAR2(36)");
        }
    }
}