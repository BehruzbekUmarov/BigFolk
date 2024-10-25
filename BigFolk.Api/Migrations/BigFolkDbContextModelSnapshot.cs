﻿// <auto-generated />
using System;
using BigFolk.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BigFolk.Api.Migrations
{
    [DbContext(typeof(BigFolkDbContext))]
    partial class BigFolkDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BigFolk.Api.Models.Domain.Car", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("GeniusId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GeniusId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("BigFolk.Api.Models.Domain.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GeniusId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsUnicorn")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GeniusId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("BigFolk.Api.Models.Domain.Genius", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Geniuses");
                });

            modelBuilder.Entity("BigFolk.Api.Models.Domain.Habit", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Frequency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("GeniusId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GeniusId");

                    b.ToTable("Habits");
                });

            modelBuilder.Entity("BigFolk.Api.Models.Domain.HouseSystem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("SmartHouseId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("SmartHouseId")
                        .IsUnique();

                    b.ToTable("HouseSystems");
                });

            modelBuilder.Entity("BigFolk.Api.Models.Domain.Portfolio", b =>
                {
                    b.Property<Guid>("GeniusId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SkillId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("GeniusId", "SkillId");

                    b.HasIndex("SkillId");

                    b.ToTable("Portfolios");
                });

            modelBuilder.Entity("BigFolk.Api.Models.Domain.Skill", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("BigFolk.Api.Models.Domain.SmartHouse", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("GeniusId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GeniusId");

                    b.ToTable("SmartHouses");
                });

            modelBuilder.Entity("BigFolk.Api.Models.Domain.Car", b =>
                {
                    b.HasOne("BigFolk.Api.Models.Domain.Genius", "Genius")
                        .WithMany("Cars")
                        .HasForeignKey("GeniusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genius");
                });

            modelBuilder.Entity("BigFolk.Api.Models.Domain.Company", b =>
                {
                    b.HasOne("BigFolk.Api.Models.Domain.Genius", "Genius")
                        .WithMany("Companies")
                        .HasForeignKey("GeniusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genius");
                });

            modelBuilder.Entity("BigFolk.Api.Models.Domain.Habit", b =>
                {
                    b.HasOne("BigFolk.Api.Models.Domain.Genius", "Genius")
                        .WithMany("Habits")
                        .HasForeignKey("GeniusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genius");
                });

            modelBuilder.Entity("BigFolk.Api.Models.Domain.HouseSystem", b =>
                {
                    b.HasOne("BigFolk.Api.Models.Domain.SmartHouse", "SmartHouse")
                        .WithOne("HouseSystem")
                        .HasForeignKey("BigFolk.Api.Models.Domain.HouseSystem", "SmartHouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SmartHouse");
                });

            modelBuilder.Entity("BigFolk.Api.Models.Domain.Portfolio", b =>
                {
                    b.HasOne("BigFolk.Api.Models.Domain.Genius", "Genius")
                        .WithMany("Portfolios")
                        .HasForeignKey("GeniusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BigFolk.Api.Models.Domain.Skill", "Skill")
                        .WithMany("Portfolios")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genius");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("BigFolk.Api.Models.Domain.SmartHouse", b =>
                {
                    b.HasOne("BigFolk.Api.Models.Domain.Genius", "Genius")
                        .WithMany("SmartHouses")
                        .HasForeignKey("GeniusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genius");
                });

            modelBuilder.Entity("BigFolk.Api.Models.Domain.Genius", b =>
                {
                    b.Navigation("Cars");

                    b.Navigation("Companies");

                    b.Navigation("Habits");

                    b.Navigation("Portfolios");

                    b.Navigation("SmartHouses");
                });

            modelBuilder.Entity("BigFolk.Api.Models.Domain.Skill", b =>
                {
                    b.Navigation("Portfolios");
                });

            modelBuilder.Entity("BigFolk.Api.Models.Domain.SmartHouse", b =>
                {
                    b.Navigation("HouseSystem");
                });
#pragma warning restore 612, 618
        }
    }
}
