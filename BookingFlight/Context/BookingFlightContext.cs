using BookingFlight.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

        public DbSet<Passenger> HangKhachs { get; set; }

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
            // --- Flight ---
            modelBuilder.Entity<Flight>().ToTable("Flight");
            modelBuilder.Entity<Flight>().HasKey(p => new { p.Ma, p.Ngay ,p.Hang, p.MucGia });
            modelBuilder.Entity<Flight>().HasMany(p => p.Bookings).WithMany(p => p.Flights).Map(m =>
            {
                m.ToTable("FlightDetail");
                m.MapRightKey("MaDatCho");
                m.MapLeftKey("Ma", "Ngay", "Hang", "MucGia");
            });

            // --- Booking ---
            modelBuilder.Entity<Booking>().ToTable("Booking");
            modelBuilder.Entity<Booking>().HasKey(p => p.Ma);

            // --- HangKhach ---
            modelBuilder.Entity<Passenger>().ToTable("Passenger");
            modelBuilder.Entity<Passenger>().HasKey(p => p.MaDatCho);

            base.OnModelCreating(modelBuilder);
        }
    }

    public class CustomeDBContextInitializer : DropCreateDatabaseAlways<BookingFlightContext>
    {
        // ---- HERE ----
        // A method that should be overridden to actually add data to the context for seeding.
        protected override void Seed(BookingFlightContext context)
        {
            IList<Flight> flights = GetSeedFlight(context);
            context.Flights.AddRange(flights);
            context.SaveChanges();
            base.Seed(context);
        }

        IList<Flight> GetSeedFlight(BookingFlightContext context)
        {
            IList<Flight> flights = new List<Flight>();

            Booking booking = new Booking
            {
                Ma = "ABCXYZ",
                ThoiGianDatCho = DateTime.Now,
                TongTien = 10000,
                TrangThai = false
            };

            // Just demonstrate, use another solution on datetime
            flights.Add(new Flight
            {
                Ma = "BL326",
                NoiDi = "SGN",
                NoiDen = "TTB",
                Ngay = DateTime.Now,
                Gio = DateTime.Now,
                Hang = Hang.Y,
                MucGia = MucGia.E,
                Bookings = new List<Booking> { booking}
            });

            flights.Add(new Flight
            {
                Ma = "BL326",
                NoiDi = "SGN",
                NoiDen = "TTB",
                Ngay = DateTime.Now,
                Gio = DateTime.Now,
                Hang = Hang.Y,
                MucGia = MucGia.F
            });

            flights.Add(new Flight
            {
                Ma = "BL326",
                NoiDi = "SGN",
                NoiDen = "TTB",
                Ngay = DateTime.Now,
                Gio = DateTime.Now,
                Hang = Hang.C,
                MucGia = MucGia.G
            });

            flights.Add(new Flight
            {
                Ma = "BL327",
                NoiDi = "TTB",
                NoiDen = "SGN",
                Ngay = DateTime.Now,
                Gio = DateTime.Now,
                Hang = Hang.Y,
                MucGia = MucGia.E,
                Bookings = new List<Booking> { booking}
            });

            return flights;
        }
    }
}
