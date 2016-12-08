using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoubleBooking.Domain.Entities;
using DoubleBooking.Domain.Model;
using DoubleBooking.Infrastructure.Data;

namespace DoubleBooking.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDoubleBookingContext db;
        private readonly IBookingsController bookingsController;

        public HomeController(IDoubleBookingContext db, IBookingsController bookingsController)
        {
            this.db = db;
            this.bookingsController = bookingsController;
        }

        public ActionResult Index()
        {
            BookingsViewModel model = new BookingsViewModel
            {
                LocalAuthorities = GetLocalAuthorities()
            };

            return View(model);
        }

        [OutputCache(Duration = 360000)]
        private IEnumerable<SelectListItem> GetLocalAuthorities()
        {
            return db.LocalAuthorities.Select(x =>
                        new SelectListItem
                        {
                            Value = x.Id.ToString(),
                            Text = x.LocalAuthoritiesName
                        });
        }

        [HttpPost]
        public ActionResult Index(BookingsViewModel model)
        {
            ViewBag.message = string.Empty;
            try
            {
                model.LocalAuthorities = GetLocalAuthorities();

                var clerk = db.Clerks.FirstOrDefault(x => x.Email.Equals(model.Email.Trim(), StringComparison.OrdinalIgnoreCase));
                if (clerk == null)
                {
                    clerk = new Clerk { Email = model.Email };
                    db.Clerks.Add(clerk);
                    db.SaveChanges();
                }
    
                var localAuth = db.LocalAuthorities.First(x => x.Id.Equals(model.SelectedLocalAuthorities));

                Booking booking = new Booking
                {
                    Clerk = clerk,
                    LocalAuthorities = localAuth,
                    DateBooking = model.DateBooking
                };

                bookingsController.PostBooking(booking);

                ViewBag.message = "Successfully booked!";
            }
            catch (Exception ex)
            {
                ViewBag.message = "Error:" + ex.Message;
            }


            return View(model);
        }


        public ActionResult Report()
        {
            BookingsViewModel model = new BookingsViewModel();
            model.LocalAuthorities = GetLocalAuthorities();

            var results = from b in db.Bookings
                group b by b.LocalAuthorities
                into g
                select new BookingReportViewModel
                {
                    LocalAuthoritieName = g.Key.LocalAuthoritiesName,
                    DoubleBooked = g.Count()
                };

            return View(results);
        }

    }
}