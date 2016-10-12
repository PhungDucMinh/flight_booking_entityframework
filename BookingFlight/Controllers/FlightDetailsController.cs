using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using BookingFlight.Context;
using BookingFlight.Models;

namespace BookingFlight.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using BookingFlight.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<FlightDetail>("FlightDetails");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class FlightDetailsController : ODataController
    {
        private BookingFlightContext db = new BookingFlightContext();

        // GET: odata/FlightDetails
        [EnableQuery]
        public IQueryable<FlightDetail> GetFlightDetails()
        {
            return db.FlightDetails;
        }

        // GET: odata/FlightDetails(5)
        [EnableQuery]
        public SingleResult<FlightDetail> GetFlightDetail([FromODataUri] int key)
        {
            return SingleResult.Create(db.FlightDetails.Where(flightDetail => flightDetail.Id == key));
        }

        // PUT: odata/FlightDetails(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<FlightDetail> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            FlightDetail flightDetail = db.FlightDetails.Find(key);
            if (flightDetail == null)
            {
                return NotFound();
            }

            patch.Put(flightDetail);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlightDetailExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(flightDetail);
        }

        // POST: odata/FlightDetails
        public IHttpActionResult Post(FlightDetail flightDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FlightDetails.Add(flightDetail);
            db.SaveChanges();

            return Created(flightDetail);
        }

        // PATCH: odata/FlightDetails(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<FlightDetail> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            FlightDetail flightDetail = db.FlightDetails.Find(key);
            if (flightDetail == null)
            {
                return NotFound();
            }

            patch.Patch(flightDetail);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlightDetailExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(flightDetail);
        }

        // DELETE: odata/FlightDetails(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            FlightDetail flightDetail = db.FlightDetails.Find(key);
            if (flightDetail == null)
            {
                return NotFound();
            }

            db.FlightDetails.Remove(flightDetail);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FlightDetailExists(int key)
        {
            return db.FlightDetails.Count(e => e.Id == key) > 0;
        }
    }
}
