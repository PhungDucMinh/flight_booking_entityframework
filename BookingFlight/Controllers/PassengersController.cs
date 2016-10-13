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
    public class PassengersController : ApiController
    {
        private BookingFlightContext db = new BookingFlightContext();

        // GET: api/HangKhaches
        public IQueryable<Passenger> GetHangKhachs()
        {
            return db.HangKhachs;
        }

        // GET: api/HangKhaches/5
        [ResponseType(typeof(Passenger))]
        public IHttpActionResult GetHangKhach(string id)
        {
            Passenger hangKhach = db.HangKhachs.Find(id);
            if (hangKhach == null)
            {
                return NotFound();
            }

            return Ok(hangKhach);
        }

        // PUT: api/HangKhaches/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHangKhach(string id, Passenger hangKhach)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hangKhach.MaDatCho)
            {
                return BadRequest();
            }

            db.Entry(hangKhach).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HangKhachExists(id))
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

        // POST: api/HangKhaches
        [ResponseType(typeof(Passenger))]
        public IHttpActionResult PostHangKhach(Passenger hangKhach)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.HangKhachs.Add(hangKhach);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (HangKhachExists(hangKhach.MaDatCho))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = hangKhach.MaDatCho }, hangKhach);
        }

        // DELETE: api/HangKhaches/5
        [ResponseType(typeof(Passenger))]
        public IHttpActionResult DeleteHangKhach(string id)
        {
            Passenger hangKhach = db.HangKhachs.Find(id);
            if (hangKhach == null)
            {
                return NotFound();
            }

            db.HangKhachs.Remove(hangKhach);
            db.SaveChanges();

            return Ok(hangKhach);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HangKhachExists(string id)
        {
            return db.HangKhachs.Count(e => e.MaDatCho == id) > 0;
        }
    }
}