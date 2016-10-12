using BookingFlight.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookingFlight.Context
{
    public class BookingFlightContext : DbContext
    {

        #region Properties

        public DbSet<Flight> Flights { get; set; }

        public DbSet<Booking> Bookings { get; set; }

        public DbSet<FlightDetail> FlightDetails { get; set; }

        public DbSet<HangKhach> HangKhachs { get; set; }

        #endregion

        #region Constructor

        public BookingFlightContext() : base("name=BookingFlightContext")
        {
            // Set how to init database
            Database.SetInitializer<BookingFlightContext>(new CustomeDBContextInitializer());
        }

        #endregion

        // Create fucking mapping
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Database nháp của thầy có nhiều vấn đề lắm
            // Nên tốt nhất đừng chơi theo kiểu convention tạo khóa ngoại làm gì
            // Cứ ko có khóa ngoại để tránh nhiều vấn đề xảy ra

            // --- Flight ---
            // Buộc phải thêm thằng này zô vì éo thể set key = MA được do có thể trùng trong db
            modelBuilder.Entity<Flight>().HasKey(p => p.Id);


            // --- Booking ---
            modelBuilder.Entity<Booking>().HasKey(p => p.Ma);

            // --- FlightDetail ---
            modelBuilder.Entity<FlightDetail>().HasKey(p => p.Id);

            // --- HangKhach ---
            modelBuilder.Entity<HangKhach>().HasKey(p => p.Id);

            base.OnModelCreating(modelBuilder);
        }
    }

    public class CustomeDBContextInitializer : DropCreateDatabaseIfModelChanges<DbContext>
    {
        // ---- HERE ----
        // A method that should be overridden to actually add data to the context for seeding.
        protected override void Seed(DbContext context)
        {
            base.Seed(context);
        }
    }
}
