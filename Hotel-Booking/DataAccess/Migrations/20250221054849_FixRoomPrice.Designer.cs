﻿// <auto-generated />
using System;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250221054849_FixRoomPrice")]
    partial class FixRoomPrice
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Models.BookingDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BranchId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CheckInDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CheckOutDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReservationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("Models.BookingRoomDetails", b =>
                {
                    b.Property<int>("BookingDetailsId")
                        .HasColumnType("int");

                    b.Property<int>("RoomTypeId")
                        .HasColumnType("int");

                    b.Property<int>("NoOfAdults")
                        .HasColumnType("int");

                    b.Property<int>("NoOfChildren")
                        .HasColumnType("int");

                    b.HasKey("BookingDetailsId", "RoomTypeId");

                    b.HasIndex("RoomTypeId");

                    b.ToTable("BookingRoomDetails");
                });

            modelBuilder.Entity("Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("NationalId")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Models.HotelBranch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("HotelBranches");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Cairo",
                            Name = "Main Branch"
                        },
                        new
                        {
                            Id = 2,
                            City = "Aswan",
                            Name = "Aswan Branch"
                        },
                        new
                        {
                            Id = 3,
                            City = "Sharm Elshiekh",
                            Name = "Sharm Branch"
                        });
                });

            modelBuilder.Entity("Models.HotelRoom", b =>
                {
                    b.Property<int>("BranchId")
                        .HasColumnType("int");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<int>("NoOfRooms")
                        .HasColumnType("int");

                    b.Property<double>("PricePerNight")
                        .HasColumnType("float");

                    b.HasKey("BranchId", "RoomId");

                    b.HasIndex("RoomId");

                    b.ToTable("HotelRooms");

                    b.HasData(
                        new
                        {
                            BranchId = 1,
                            RoomId = 1,
                            NoOfRooms = 50,
                            PricePerNight = 100.0
                        },
                        new
                        {
                            BranchId = 1,
                            RoomId = 2,
                            NoOfRooms = 50,
                            PricePerNight = 175.0
                        },
                        new
                        {
                            BranchId = 1,
                            RoomId = 3,
                            NoOfRooms = 50,
                            PricePerNight = 250.0
                        },
                        new
                        {
                            BranchId = 2,
                            RoomId = 1,
                            NoOfRooms = 50,
                            PricePerNight = 120.0
                        },
                        new
                        {
                            BranchId = 2,
                            RoomId = 2,
                            NoOfRooms = 50,
                            PricePerNight = 200.0
                        },
                        new
                        {
                            BranchId = 2,
                            RoomId = 3,
                            NoOfRooms = 50,
                            PricePerNight = 320.0
                        },
                        new
                        {
                            BranchId = 3,
                            RoomId = 1,
                            NoOfRooms = 50,
                            PricePerNight = 175.0
                        },
                        new
                        {
                            BranchId = 3,
                            RoomId = 2,
                            NoOfRooms = 50,
                            PricePerNight = 230.0
                        },
                        new
                        {
                            BranchId = 3,
                            RoomId = 3,
                            NoOfRooms = 50,
                            PricePerNight = 400.0
                        });
                });

            modelBuilder.Entity("Models.RoomType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AdultCapacity")
                        .HasColumnType("int");

                    b.Property<int>("ChildCapacity")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RoomTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AdultCapacity = 1,
                            ChildCapacity = 1,
                            Type = "Single"
                        },
                        new
                        {
                            Id = 2,
                            AdultCapacity = 2,
                            ChildCapacity = 2,
                            Type = "Double"
                        },
                        new
                        {
                            Id = 3,
                            AdultCapacity = 4,
                            ChildCapacity = 4,
                            Type = "Suite"
                        });
                });

            modelBuilder.Entity("Models.BookingDetails", b =>
                {
                    b.HasOne("Models.HotelBranch", "HotelBranch")
                        .WithMany()
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("HotelBranch");
                });

            modelBuilder.Entity("Models.BookingRoomDetails", b =>
                {
                    b.HasOne("Models.BookingDetails", "BookingDetails")
                        .WithMany("RoomDetails")
                        .HasForeignKey("BookingDetailsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.RoomType", "RoomType")
                        .WithMany("RoomDetails")
                        .HasForeignKey("RoomTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BookingDetails");

                    b.Navigation("RoomType");
                });

            modelBuilder.Entity("Models.HotelRoom", b =>
                {
                    b.HasOne("Models.HotelBranch", "HotelBranch")
                        .WithMany("HotelRooms")
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.RoomType", "RoomType")
                        .WithMany("HotelRooms")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HotelBranch");

                    b.Navigation("RoomType");
                });

            modelBuilder.Entity("Models.BookingDetails", b =>
                {
                    b.Navigation("RoomDetails");
                });

            modelBuilder.Entity("Models.HotelBranch", b =>
                {
                    b.Navigation("HotelRooms");
                });

            modelBuilder.Entity("Models.RoomType", b =>
                {
                    b.Navigation("HotelRooms");

                    b.Navigation("RoomDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
