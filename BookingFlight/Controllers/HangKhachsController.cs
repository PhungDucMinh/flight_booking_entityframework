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
    public class HangKhachsController : ApiController
    {
        private BookingFlightContext db = new BookingFlightContext();

        // GET: api/HangKhachs
        public IQueryable<HangKhach> GetHangKhachs()
        {
            return db.HangKhachs;
        }

        // GET: api/HangKhachs/5
        [ResponseType(typeof(HangKhach))]
        public IHttpActionResult GetHangKhach(int id)
        {
            HangKhach hangKhach = db.HangKhachs.Find(id);
            if (hangKhach == null)
            {
                return NotFound();
            }

            return Ok(hangKhach);
        }

        // PUT: api/HangKhachs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHangKhach(int id, HangKhach hangKhach)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hangKhach.Id)
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

        // POST: api/HangKhachs
        [ResponseType(typeof(HangKhach))]
        public IHttpActionResult PostHangKhach(HangKhach hangKhach)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.HangKhachs.Add(hangKhach);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = hangKhach.Id }, hangKhach);
        }

        // DELETE: api/HangKhachs/5
        [ResponseType(typeof(HangKhach))]
        public IHttpActionResult DeleteHangKhach(int id)
        {
            HangKhach hangKhach = db.HangKhachs.Find(id);
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

        private bool HangKhachExists(int id)
        {
            return db.HangKhachs.Count(e => e.Id == id) > 0;
        }
    }
}