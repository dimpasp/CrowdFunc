﻿// <auto-generated />
using System;
using CrowdFun.Core.data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CrowdFun.Core.Migrations
{
    [DbContext(typeof(CrowdFunDbContext))]
    [Migration("20200220140529_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CrowdFun.Core.model.BackerReward", b =>
                {
                    b.Property<int>("BackerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BackersId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("RewardsId")
                        .HasColumnType("int");

                    b.HasKey("BackerId");

                    b.HasIndex("BackersId");

                    b.HasIndex("RewardsId");

                    b.ToTable("BackerReward");
                });

            modelBuilder.Entity("CrowdFun.Core.model.Backers", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.HasIndex("FirstName")
                        .IsUnique()
                        .HasFilter("[FirstName] IS NOT NULL");

                    b.HasIndex("LastName")
                        .IsUnique()
                        .HasFilter("[LastName] IS NOT NULL");

                    b.ToTable("Backer");
                });

            modelBuilder.Entity("CrowdFun.Core.model.Creator", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("LastName")
                        .IsUnique()
                        .HasFilter("[LastName] IS NOT NULL");

                    b.ToTable("Creator");
                });

            modelBuilder.Entity("CrowdFun.Core.model.Project", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BackersId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CreatorId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Photos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Projectid")
                        .HasColumnType("int");

                    b.Property<string>("Tittle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("UpdateStatus")
                        .HasColumnType("bit");

                    b.Property<string>("Videos")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("BackersId");

                    b.HasIndex("CreatorId");

                    b.HasIndex("Projectid");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("CrowdFun.Core.model.Reward", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatorId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Projectid")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Value")
                        .HasColumnType("real");

                    b.Property<string>("backersId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("Projectid");

                    b.HasIndex("backersId");

                    b.ToTable("Reward");
                });

            modelBuilder.Entity("CrowdFun.Core.model.BackerReward", b =>
                {
                    b.HasOne("CrowdFun.Core.model.Backers", "Backers")
                        .WithMany("RewardsProject")
                        .HasForeignKey("BackersId");

                    b.HasOne("CrowdFun.Core.model.Reward", "Rewards")
                        .WithMany("Backre")
                        .HasForeignKey("RewardsId");
                });

            modelBuilder.Entity("CrowdFun.Core.model.Project", b =>
                {
                    b.HasOne("CrowdFun.Core.model.Backers", null)
                        .WithMany("GettingProject")
                        .HasForeignKey("BackersId");

                    b.HasOne("CrowdFun.Core.model.Creator", null)
                        .WithMany("Project_")
                        .HasForeignKey("CreatorId");

                    b.HasOne("CrowdFun.Core.model.Project", null)
                        .WithMany("Projects")
                        .HasForeignKey("Projectid");
                });

            modelBuilder.Entity("CrowdFun.Core.model.Reward", b =>
                {
                    b.HasOne("CrowdFun.Core.model.Creator", null)
                        .WithMany("Rewards_")
                        .HasForeignKey("CreatorId");

                    b.HasOne("CrowdFun.Core.model.Project", null)
                        .WithMany("Rewards")
                        .HasForeignKey("Projectid");

                    b.HasOne("CrowdFun.Core.model.Backers", "backers")
                        .WithMany()
                        .HasForeignKey("backersId");
                });
#pragma warning restore 612, 618
        }
    }
}
