using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BookingFlight.Context;
using BookingFlight.Models;

namespace BookingFlight.Controllers
{
    public class FlightDetailsController : ApiController
    {
        private BookingFlightContext db = new BookingFlightContext();

        // GET: api/FlightDetails
        public IQueryable<FlightDetail> GetFlightDetails()
        {
            return db.FlightDetails;
        }

        // GET: api/FlightDetails/5
        [ResponseType(typeof(FlightDetail))]
        public IHttpActionResult GetFlightDetail(int id)
        {
            FlightDetail flightDetail = db.FlightDetails.Find(id);
            if (flightDetail == null)
            {
                return NotFound();
            }

            return Ok(flightDetail);
        }

        // PUT: api/FlightDetails/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFlightDetail(int id, FlightDetail flightDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != flightDetail.Id)
            {
                return BadRequest();
            }

            db.Entry(flightDetail).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlightDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/FlightDetails
        [ResponseType(typeof(FlightDetail))]
        public IHttpActionResult PostFlightDetail(FlightDetail flightDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FlightDetails.Add(flightDetail);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = flightDetail.Id }, flightDetail);
        }

        // DELETE: api/FlightDetails/5
        [ResponseType(typeof(FlightDetail))]
        public IHttpActionResult DeleteFlightDetail(int id)
        {
            FlightDetail flightDetail = db.FlightDetails.Find(id);
            if (flightDetail == null)
            {
                return NotFound();
            }

            db.FlightDetails.Remove(flightDetail);
            db.SaveChanges();

            return Ok(flightDetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FlightDetailExists(int id)
        {
            return db.FlightDetails.Count(e => e.Id == id) > 0;
        }
    }
}