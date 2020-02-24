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

        public DbSet<Backer> Backers { get; set; }
        public DbSet<Creator> Creators { get; set; }
        public DbSet<Project> Projects { get; set; }

        public DbSet<Reward> Rewards { get; set; }


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

            // Configure Many to Many Relationship
            //modelBuilder.Entity<Reward>().HasKey(r => new { r.BackerId, r.ProjectId });

            //modelBuilder.Entity<Reward>().
            //    HasOne(r => r.Project).
            //    WithMany(p => p.Rewards).
            //    HasForeignKey(r => r.ProjectId);

            //modelBuilder.Entity<Reward>().
            //   HasOne(r => r.Backer).
            //   WithMany(b => b.Rewards).
            //   HasForeignKey(r => r.BackerId);

            // Configure One to Many Relationship
            modelBuilder.
                Entity<Creator>().
                HasMany(c => c.Projects).
                WithOne(p => p.Creator);

            // Configure One to Many Relationship
            modelBuilder.
                Entity<Project>().
                HasMany(p => p.Rewards).
                WithOne(r => r.Project);

            // Configure One to Many Relationship
            modelBuilder.
                Entity<Backer>()
                .ToTable("Backer");
                //HasMany(b => b.Rewards).
                //WithOne(r => r.Backer);

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString_);
        }
    }
}

