using Microsoft.EntityFrameworkCore;
using EUC.Models;

namespace EUC.Configuration
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Questionnaire> Questionnaires { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Questionnaire>()
                .Property(o => o.Sex)
                .HasConversion<string>()
                .HasColumnType("nvarchar(255)");

            modelBuilder.Entity<Questionnaire>()
                .Property(o => o.Nationality)
                .HasConversion<string>()
                .HasColumnType("nvarchar(255)");

            base.OnModelCreating(modelBuilder);
        }
    }
}