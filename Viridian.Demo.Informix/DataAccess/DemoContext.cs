using System;
using Microsoft.EntityFrameworkCore;

namespace Viridian.Demo.Informix.DataAccess
{
    public class DemoContext : DbContext
    {
        public virtual DbSet<Users> Users { get; set; }

        public DemoContext(DbContextOptions<DemoContext> options) : base(options)
        {
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                throw new Exception("Database is not configured");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Id)
                    .HasColumnName("id");
                
                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Fullname)
                    .IsRequired()
                    .HasColumnName("fullname")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.DocId)
                    .IsRequired()
                    .HasColumnName("doc_id")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Enabled)
                    .IsRequired()
                    .HasColumnName("enabled")
                    .HasColumnType("smallint(2)");
                
                entity.Property(e => e.BirthDate)
                    .HasColumnName("birth_date")
                    .HasColumnType("datetime year to second(3594)");                
            });
        }
    }
}