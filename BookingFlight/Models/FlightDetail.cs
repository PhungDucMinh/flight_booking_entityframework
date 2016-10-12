using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingFlight.Models
{
    public class FlightDetail
    {
        public int Id { get; set; }

        public string MaDatCho { get; set; }

        public string MaChuyenBay { get; set; }

        public DateTime Ngay { get; set; }

        public Hang Hang { get; set; }

        public string MucGia { get; set; }

    }
}