﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingFlight.Models
{
    public class Passenger
    {
        public int Id { get; set; }

        public string MaDatCho { get; set; }

        public string DanhXung { get; set; }

        public string Ho { get; set; }

        public string Ten { get; set; }

        public Booking Booking { get; set; }
    }
}