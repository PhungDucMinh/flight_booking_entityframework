using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookingFlight.Models
{
    public class Flight
    {
        public string Ma { get; set; }

        public string NoiDi { get; set; }

        public string NoiDen { get; set; }

        public DateTime Ngay { get; set; }

        public DateTime Gio { get; set; }

        public Hang Hang { get; set; }

        public MucGia MucGia { get; set; }

        public int SoLuongGhe { get; set; }

        public int GiaBan { get; set; }

        public IList<Booking> Bookings { get; set; }
    }
}