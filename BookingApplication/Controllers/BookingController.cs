using BookingApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookingApplication.Controllers
{
    public class BookingController : Controller
    {
        // GET: Booking
        public ActionResult Booking()
        {
            return View();
        }

        public ActionResult _DesktopBooking()
        {
            BookingModel.BookingBrowseModel bookingModel = BookingModel.GetJuly2023Dates();
            return View(bookingModel);
        }

        public ActionResult _MobileBooking()
        {
            BookingModel.BookingBrowseModel bookingModel = BookingModel.GetJuly2023Dates();
            return View(bookingModel);
        }

        public ActionResult ContactPaymentInfo(DateTime date, TimeSpan time)
        {
            ViewBag.Date = date.ToShortDateString();
            ViewBag.Time = time.ToString();
            return View();
        }

        [HttpPost]
        public ActionResult BookDate(DateTime date, TimeSpan time)
        {
            BookingModel.BookDate(date, time);
            TempData["Success"] = "Your booking has been successfully created!";
            return RedirectToAction("Booking");
        }
        public ActionResult AdminBooking()
        {
            BookingModel.BookingBrowseModel bookingModel = BookingModel.GetJuly2023Dates();
            return View(bookingModel.Days);
        }
    }
}