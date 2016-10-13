using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingFlight.Models
{
    public class Booking
    {
        public string Ma { get; set; }

        public DateTime ThoiGianDatCho { get; set; }

        public int TongTien { get; set; }

        public bool TrangThai { get; set; }

        public IList<Flight> Flights { get; set; }

    }
}