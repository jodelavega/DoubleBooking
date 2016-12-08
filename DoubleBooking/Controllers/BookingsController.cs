using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Description;
using System.Web.Http.ModelBinding;
using System.Web.Http.Routing;
using DoubleBooking.Domain.Entities;
using DoubleBooking.Infrastructure.Data;

namespace DoubleBooking.Controllers
{
    public interface IBookingsController
    {
        IQueryable<Booking> GetBookings();
        IHttpActionResult GetBooking(int id);
        IHttpActionResult PutBooking(int id, Booking booking);
        IHttpActionResult PostBooking(Booking booking);
        IHttpActionResult DeleteBooking(int id);
        Task<HttpResponseMessage> ExecuteAsync(HttpControllerContext controllerContext, CancellationToken cancellationToken);
        void Validate<TEntity>(TEntity entity);
        void Validate<TEntity>(TEntity entity, string keyPrefix);
        void Dispose();
        HttpConfiguration Configuration { get; set; }
        HttpControllerContext ControllerContext { get; set; }
        HttpActionContext ActionContext { get; set; }
        ModelStateDictionary ModelState { get; }
        HttpRequestMessage Request { get; set; }
        HttpRequestContext RequestContext { get; set; }
        UrlHelper Url { get; set; }
        IPrincipal User { get; set; }
    }

    public class BookingsController : ApiController, IBookingsController
    {
        private readonly IDoubleBookingContext db;

        public BookingsController(IDoubleBookingContext db)
        {
            this.db = db;
        }
        // GET: api/Bookings
        public IQueryable<Booking> GetBookings()
        {
            return db.Bookings;
        }

        // GET: api/Bookings/5
        [ResponseType(typeof(Booking))]
        public IHttpActionResult GetBooking(int id)
        {
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return NotFound();
            }

            return Ok(booking);
        }

        // PUT: api/Bookings/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBooking(int id, Booking booking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != booking.Id)
            {
                return BadRequest();
            }

            db.Entry(booking).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingExists(id))
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

        // POST: api/Bookings
        [ResponseType(typeof(Booking))]
        public IHttpActionResult PostBooking(Booking booking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Entry(booking.Clerk).State = EntityState.Unchanged;
            db.Entry(booking.LocalAuthorities).State = EntityState.Unchanged;
            db.Bookings.Add(booking);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = booking.Id }, booking);
        }

        // DELETE: api/Bookings/5
        [ResponseType(typeof(Booking))]
        public IHttpActionResult DeleteBooking(int id)
        {
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return NotFound();
            }

            db.Bookings.Remove(booking);
            db.SaveChanges();

            return Ok(booking);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BookingExists(int id)
        {
            return db.Bookings.Count(e => e.Id == id) > 0;
        }
    }
}