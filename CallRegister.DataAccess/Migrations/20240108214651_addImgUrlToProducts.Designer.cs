﻿// <auto-generated />
using System;
using CallRegisterWeb.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CallRegisterWeb.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240108214651_addImgUrlToProducts")]
    partial class addImgUrlToProducts
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CallRegister.Models.Agent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int?>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Agents");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Nick",
                            TeamId = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "Mark",
                            TeamId = 2
                        },
                        new
                        {
                            Id = 3,
                            Name = "David",
                            TeamId = 3
                        },
                        new
                        {
                            Id = 4,
                            Name = "Dean",
                            TeamId = 3
                        },
                        new
                        {
                            Id = 5,
                            Name = "Kenny",
                            TeamId = 4
                        });
                });

            modelBuilder.Entity("CallRegister.Models.Email", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Agent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("AllocatedDate")
                        .HasColumnType("date");

                    b.Property<DateOnly>("DateCompleted")
                        .HasColumnType("date");

                    b.Property<DateOnly>("DateDue")
                        .HasColumnType("date");

                    b.Property<bool>("Internal")
                        .HasColumnType("bit");

                    b.Property<string>("ProductType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Emails");
                });

            modelBuilder.Entity("CallRegister.Models.PhoneCall", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Agent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("AllocatedDate")
                        .HasColumnType("date");

                    b.Property<DateOnly>("DateCompleted")
                        .HasColumnType("date");

                    b.Property<DateOnly>("DateDue")
                        .HasColumnType("date");

                    b.Property<bool>("Internal")
                        .HasColumnType("bit");

                    b.Property<string>("ProductType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PhoneCalls");
                });

            modelBuilder.Entity("CallRegister.Models.Products", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ImageUrl = "",
                            Name = "Actuators"
                        },
                        new
                        {
                            Id = 2,
                            ImageUrl = "",
                            Name = "Eletric Drives"
                        },
                        new
                        {
                            Id = 3,
                            ImageUrl = "",
                            Name = "Chillers"
                        },
                        new
                        {
                            Id = 4,
                            ImageUrl = "",
                            Name = "Air Prep"
                        },
                        new
                        {
                            Id = 5,
                            ImageUrl = "",
                            Name = "Valves"
                        });
                });

            modelBuilder.Entity("CallRegister.Models.Teams", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Teams");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Distribution"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Actuators"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Air and Fluid"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Electrical"
                        });
                });

            modelBuilder.Entity("CallRegister.Models.Agent", b =>
                {
                    b.HasOne("CallRegister.Models.Teams", "Teams")
                        .WithMany()
                        .HasForeignKey("TeamId");

                    b.Navigation("Teams");
                });
#pragma warning restore 612, 618
        }
    }
}
