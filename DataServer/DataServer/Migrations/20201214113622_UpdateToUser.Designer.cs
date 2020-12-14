﻿// <auto-generated />
using System;
using DataServer.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataServer.Migrations
{
    [DbContext(typeof(MapDbContext))]
    [Migration("20201214113622_UpdateToUser")]
    partial class UpdateToUser
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("DataServer.Models.Place", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("addedByid")
                        .HasColumnType("INTEGER");

                    b.Property<string>("description")
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<double>("latitude")
                        .HasColumnType("REAL");

                    b.Property<double>("longitude")
                        .HasColumnType("REAL");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.HasIndex("addedByid");

                    b.ToTable("Places");
                });

            modelBuilder.Entity("DataServer.Models.Report<DataServer.Models.Place>", b =>
                {
                    b.Property<long>("reportId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("category")
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("description")
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<string>("reportedClass")
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<long?>("reportedItemid")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("resolved")
                        .HasColumnType("INTEGER");

                    b.HasKey("reportId");

                    b.HasIndex("reportedItemid");

                    b.ToTable("PlaceReports");
                });

            modelBuilder.Entity("DataServer.Models.Report<DataServer.Models.Review>", b =>
                {
                    b.Property<long>("reportId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("category")
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("description")
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<string>("reportedClass")
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<long?>("reportedItemid")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("resolved")
                        .HasColumnType("INTEGER");

                    b.HasKey("reportId");

                    b.HasIndex("reportedItemid");

                    b.ToTable("ReviewReports");
                });

            modelBuilder.Entity("DataServer.Models.Report<DataServer.Models.User>", b =>
                {
                    b.Property<long>("reportId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("category")
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("description")
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<string>("reportedClass")
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<long?>("reportedItemid")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("resolved")
                        .HasColumnType("INTEGER");

                    b.HasKey("reportId");

                    b.HasIndex("reportedItemid");

                    b.ToTable("UserReports");
                });

            modelBuilder.Entity("DataServer.Models.Review", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long?>("Placeid")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("addedByid")
                        .HasColumnType("INTEGER");

                    b.Property<string>("comment")
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<int>("rating")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.HasIndex("Placeid");

                    b.HasIndex("addedByid");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("DataServer.Models.User", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("auth")
                        .HasColumnType("INTEGER");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("firstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("lastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DataServer.Models.Place", b =>
                {
                    b.HasOne("DataServer.Models.User", "addedBy")
                        .WithMany("savedPlaces")
                        .HasForeignKey("addedByid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("addedBy");
                });

            modelBuilder.Entity("DataServer.Models.Report<DataServer.Models.Place>", b =>
                {
                    b.HasOne("DataServer.Models.Place", "reportedItem")
                        .WithMany()
                        .HasForeignKey("reportedItemid");

                    b.Navigation("reportedItem");
                });

            modelBuilder.Entity("DataServer.Models.Report<DataServer.Models.Review>", b =>
                {
                    b.HasOne("DataServer.Models.Review", "reportedItem")
                        .WithMany()
                        .HasForeignKey("reportedItemid");

                    b.Navigation("reportedItem");
                });

            modelBuilder.Entity("DataServer.Models.Report<DataServer.Models.User>", b =>
                {
                    b.HasOne("DataServer.Models.User", "reportedItem")
                        .WithMany()
                        .HasForeignKey("reportedItemid");

                    b.Navigation("reportedItem");
                });

            modelBuilder.Entity("DataServer.Models.Review", b =>
                {
                    b.HasOne("DataServer.Models.Place", null)
                        .WithMany("reviews")
                        .HasForeignKey("Placeid");

                    b.HasOne("DataServer.Models.User", "addedBy")
                        .WithMany()
                        .HasForeignKey("addedByid");

                    b.Navigation("addedBy");
                });

            modelBuilder.Entity("DataServer.Models.Place", b =>
                {
                    b.Navigation("reviews");
                });

            modelBuilder.Entity("DataServer.Models.User", b =>
                {
                    b.Navigation("savedPlaces");
                });
#pragma warning restore 612, 618
        }
    }
}
