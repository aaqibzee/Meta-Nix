using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Meta_Nix.Models
{
    public partial class BucketAlphaContext : DbContext
    {
        public BucketAlphaContext()
        {
        }

        public BucketAlphaContext(DbContextOptions<BucketAlphaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Advertiser> Advertisers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=DBConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Advertiser>(entity =>
            {
                entity.ToTable("Advertiser");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AdvertiserId)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.AdvertiserName)
                    .HasMaxLength(100)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
