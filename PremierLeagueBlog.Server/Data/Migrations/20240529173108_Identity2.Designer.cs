﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PremierLeagueBlog.Server.Data;

#nullable disable

namespace PremierLeagueBlog.Server.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240529173108_Identity2")]
    partial class Identity2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PremierLeagueBlog.Server.Data.Models.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Summary")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Articles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Date = new DateTime(2024, 5, 28, 19, 31, 8, 359, DateTimeKind.Local).AddTicks(3355),
                            Description = "Detailed description of the article 1...",
                            Image = "sample1.png",
                            Summary = "Sample summary of the article 1...",
                            Title = "Sample Article Title 1"
                        },
                        new
                        {
                            Id = 2,
                            Date = new DateTime(2024, 5, 27, 19, 31, 8, 359, DateTimeKind.Local).AddTicks(3378),
                            Description = "Detailed description of the article 2...",
                            Image = "sample1.png",
                            Summary = "Sample summary of the article 2...",
                            Title = "Sample Article Title 2"
                        },
                        new
                        {
                            Id = 3,
                            Date = new DateTime(2024, 5, 26, 19, 31, 8, 359, DateTimeKind.Local).AddTicks(3381),
                            Description = "Detailed description of the article 3...",
                            Image = "sample1.png",
                            Summary = "Sample summary of the article 3...",
                            Title = "Sample Article Title 3"
                        },
                        new
                        {
                            Id = 4,
                            Date = new DateTime(2024, 5, 25, 19, 31, 8, 359, DateTimeKind.Local).AddTicks(3384),
                            Description = "Detailed description of the article 4...",
                            Image = "sample1.png",
                            Summary = "Sample summary of the article 4...",
                            Title = "Sample Article Title 4"
                        },
                        new
                        {
                            Id = 5,
                            Date = new DateTime(2024, 5, 24, 19, 31, 8, 359, DateTimeKind.Local).AddTicks(3386),
                            Description = "Detailed description of the article 5...",
                            Image = "sample1.png",
                            Summary = "Sample summary of the article 5...",
                            Title = "Sample Article Title 5"
                        },
                        new
                        {
                            Id = 6,
                            Date = new DateTime(2024, 5, 23, 19, 31, 8, 359, DateTimeKind.Local).AddTicks(3388),
                            Description = "Detailed description of the article 6...",
                            Image = "sample1.png",
                            Summary = "Sample summary of the article 6...",
                            Title = "Sample Article Title 6"
                        },
                        new
                        {
                            Id = 7,
                            Date = new DateTime(2024, 5, 22, 19, 31, 8, 359, DateTimeKind.Local).AddTicks(3390),
                            Description = "Detailed description of the article 7...",
                            Image = "sample1.png",
                            Summary = "Sample summary of the article 7...",
                            Title = "Sample Article Title 7"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
