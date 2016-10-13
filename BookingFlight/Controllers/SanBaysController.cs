using BookingFlight.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookingFlight.Controllers
{
    public class SanBaysController : ApiController
    {
        private BookingFlightContext db = new BookingFlightContext();

        // GET: api/SanBays
        public IEnumerable<string> Get()
        {
            var sanBays = db.Flights.Select(p => p.NoiDi).Distinct();
            return sanBays;
        }

        // GET: api/SanBays/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/SanBays
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/SanBays/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/SanBays/5
        public void Delete(int id)
        {
        }
    }
}
