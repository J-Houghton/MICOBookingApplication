﻿using BookingApplication.Models;
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
            if (Request.Browser.IsMobileDevice)
            {
                return RedirectToAction("_MobileBooking");
            }
            else
            {
                return RedirectToAction("_DesktopBooking");
            }
        }

        public ActionResult _DesktopBooking()
        {
            BookingModel.BookingBrowseModel bookingModel = BookingModel.GetJuly2023Dates();
            return View(bookingModel);
        }

        public ActionResult _MobileBooking()
        {
            // Your logic
            return View();
        }
    }
}