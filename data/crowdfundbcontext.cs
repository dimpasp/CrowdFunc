using System;
using System.Collections.Generic;
using System.Text;
using CrowdFun.Core.model;
using Microsoft.EntityFrameworkCore;

namespace CrowdFun.Core.data
{
    public class CrowdFunDbContext : DbContext
    {
        private readonly string connectionString_;

        public CrowdFunDbContext() : base()
        {
            connectionString_ = "Server=localhost;Database=CrowdFun;User Id=sa;Password=QWE123!@#";
        }

        public CrowdFunDbContext(string connString)
        {
            connectionString_ = connString;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.
                Entity<Backers>().
                ToTable("Backer");

            modelBuilder.
                Entity<Backers>().
                HasIndex(v => v.FirstName)
                .IsUnique();

            modelBuilder.
               Entity<Backers>().
               HasIndex(v => v.LastName)
               .IsUnique();

            modelBuilder.
                Entity<Backers>().
                HasIndex(v => v.Email)
                .IsUnique();

            modelBuilder.
                Entity<Creator>().
                ToTable("Creator");

            modelBuilder
               .Entity<Creator>()
               .Property(v => v.FirstName)
               .IsRequired();

            modelBuilder
                .Entity<Creator>()
                .HasIndex(v => v.LastName)
                .IsUnique();

            modelBuilder
                .Entity<Creator>()
                .HasIndex(v => v.Id)
                .IsUnique();
            modelBuilder
              .Entity<BackerReward>()
              .HasKey(op => new { op.BackerId, });
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString_);
        }
    }
}

