using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DataAccess.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContext): base(dbContext) { }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<HotelBranch> HotelBranches { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<BookingRoomDetails> BookingRoomDetails { get; set; }
        public DbSet<BookingDetails> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<HotelBranch>().HasMany(x => x.RoomTypes).WithMany(x => x.HotelBranches).UsingEntity<HotelRoom>();
            modelBuilder.Entity<BookingDetails>().HasMany(x=>x.RoomTypes).WithMany(x=>x.BookingDetails).UsingEntity<BookingRoomDetails>();
            modelBuilder.Entity<RoomType>().HasData(
                new RoomType
                {
                    Id = 1,
                    Type = "Single",
                    AdultCapacity=1,
                    ChildCapacity=1,
                },
                new RoomType
                {
                    Id = 2,
                    Type = "Double",
                    AdultCapacity=2,
                    ChildCapacity=2,
                },
                new RoomType
                {
                    Id = 3,
                    Type = "Suite",
                    AdultCapacity=4,
                    ChildCapacity=4,
                });
            modelBuilder.Entity<HotelBranch>().HasData(
                new HotelBranch
                {
                    Id = 1,
                    Name = "Main Branch",
                    City = "Cairo"
                },
                new HotelBranch
                {
                    Id = 2,
                    Name = "Aswan Branch",
                    City = "Aswan"
                },
                new HotelBranch
                {
                    Id = 3,
                    Name = "Sharm Branch",
                    City = "Sharm Elshiekh"
                });
            modelBuilder.Entity<HotelRoom>().HasData(
                new HotelRoom
                {
                    BranchId = 1,
                    RoomId = 1,
                    NoOfRooms = 50,
                    PricePerNight = 100
                },
                new HotelRoom
                {
                    BranchId = 1,
                    RoomId = 2,
                    NoOfRooms = 50,
                    PricePerNight = 175
                },
                new HotelRoom
                {
                    BranchId = 1,
                    RoomId = 3,
                    NoOfRooms = 50,
                    PricePerNight = 250
                },
                new HotelRoom
                {
                    BranchId = 2,
                    RoomId = 1,
                    NoOfRooms = 50,
                    PricePerNight = 120
                },
                new HotelRoom
                {
                    BranchId = 2,
                    RoomId = 2,
                    NoOfRooms = 50,
                    PricePerNight = 200
                },
                new HotelRoom
                {
                    BranchId = 2,
                    RoomId = 3,
                    NoOfRooms = 50,
                    PricePerNight = 320
                },
                new HotelRoom
                {
                    BranchId = 3,
                    RoomId = 1,
                    NoOfRooms = 50,
                    PricePerNight = 175
                },
                new HotelRoom
                {
                    BranchId = 3,
                    RoomId = 2,
                    NoOfRooms = 50,
                    PricePerNight = 230
                },
                new HotelRoom
                {
                    BranchId = 3,
                    RoomId = 3,
                    NoOfRooms = 50,
                    PricePerNight = 400
                });

        }
    }
}
