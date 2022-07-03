﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WeddingPlanner.Models;

#nullable disable

namespace WeddingPlanner.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20220628043325_firstMiWedding3")]
    partial class firstMiWedding3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("WeddingPlanner.Models.Association", b =>
                {
                    b.Property<int>("AssociationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.Property<int?>("WeddingID")
                        .HasColumnType("int");

                    b.HasKey("AssociationID");

                    b.HasIndex("UserID");

                    b.HasIndex("WeddingID");

                    b.ToTable("Associations");
                });

            modelBuilder.Entity("WeddingPlanner.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAT")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAT")
                        .HasColumnType("datetime(6)");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WeddingPlanner.Models.Wedding", b =>
                {
                    b.Property<int>("WeddingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedAT")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Guest")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAT")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("WedderOne")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("WedderTwo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("WeddingID");

                    b.ToTable("Weddings");
                });

            modelBuilder.Entity("WeddingPlanner.Models.Association", b =>
                {
                    b.HasOne("WeddingPlanner.Models.User", "User")
                        .WithMany("Weddings")
                        .HasForeignKey("UserID");

                    b.HasOne("WeddingPlanner.Models.Wedding", "Wedding")
                        .WithMany("Users")
                        .HasForeignKey("WeddingID");

                    b.Navigation("User");

                    b.Navigation("Wedding");
                });

            modelBuilder.Entity("WeddingPlanner.Models.User", b =>
                {
                    b.Navigation("Weddings");
                });

            modelBuilder.Entity("WeddingPlanner.Models.Wedding", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
