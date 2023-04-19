﻿// <auto-generated />
using System;
using ApiSimple.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiSimple.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230419195103_01init")]
    partial class _01init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ApiSimple.Models.Classroom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Classrooms");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "P4"
                        },
                        new
                        {
                            Id = 2,
                            Name = "P3"
                        });
                });

            modelBuilder.Entity("ApiSimple.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ClassroomId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClassroomId");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BirthDate = new DateTime(2004, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ClassroomId = 1,
                            Firstname = "Cyril",
                            Lastname = "Cvrček"
                        },
                        new
                        {
                            Id = 2,
                            BirthDate = new DateTime(2005, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ClassroomId = 2,
                            Firstname = "Jana",
                            Lastname = "Jánská"
                        },
                        new
                        {
                            Id = 3,
                            BirthDate = new DateTime(2003, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ClassroomId = 1,
                            Firstname = "Adam",
                            Lastname = "Alois"
                        });
                });

            modelBuilder.Entity("ApiSimple.Models.Student", b =>
                {
                    b.HasOne("ApiSimple.Models.Classroom", "Classroom")
                        .WithMany("Students")
                        .HasForeignKey("ClassroomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Classroom");
                });

            modelBuilder.Entity("ApiSimple.Models.Classroom", b =>
                {
                    b.Navigation("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
