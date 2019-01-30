using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace QueueSystem.Models
{
    public partial class QueueSystemContext : DbContext
    {
        public QueueSystemContext()
        {
        }

        public QueueSystemContext(DbContextOptions<QueueSystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Queue> Queue { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(local);Initial Catalog=QueueSystem;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.Entity<Queue>(entity =>
            {
                entity.HasKey(e => e.QueueNo);

                entity.Property(e => e.QueueType)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });
        }
    }
}
