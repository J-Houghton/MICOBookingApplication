using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using static BookingApplication.Models.BookingModel;

namespace BookingApplication.Models
{
    public class BookingModel
    {
        public static List<Booking> Bookings { get; set; } = new List<Booking>();
        public static BookingBrowseModel CurrentModel { get; set; } = null;
        public class BookingBrowseModel
        {
            public List<CalendarDay> Days { get; set; }
            public List<string> DaysOfWeek = new List<string>()
                {
                    "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"
                };
            public BookingBrowseModel()
            {
                Days = new List<CalendarDay>();
            }
        }

        public static void BookDate(DateTime date, TimeSpan time)
        {
            CalendarDay day = GetJuly2023Dates().Days.FirstOrDefault(d => d.Date.Date == date.Date);
            if (day != null)
            {
                CalendarHour hour = day.Hours.FirstOrDefault(h => h.Time == time);
                if (hour != null && hour.IsAvailable)
                {
                    hour.IsAvailable = false;
                    day.UnavailableHours.Add(hour);
                    Bookings.Add(new Booking { Day = day, Hour = hour });
                }
            }
        }

        public class CalendarDay
        {
            public DateTime Date { get; set; }
            public List<CalendarHour> Hours { get; set; }
            public List<CalendarHour> UnavailableHours { get; set; } = new List<CalendarHour>();
        }
        public class CalendarHour
        {
            public TimeSpan Time { get; set; }
            public bool IsAvailable { get; set; }
        }

        public static BookingBrowseModel GetJuly2023Dates()
        {
            if (CurrentModel != null) return CurrentModel;

            BookingBrowseModel bookingModel = new BookingBrowseModel();

            DateTime startDate = new DateTime(2023, 7, 1);
            DateTime endDate = new DateTime(2023, 7, 31);

            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            {
                CalendarDay calendarDay = new CalendarDay();
                calendarDay.Date = date;
                calendarDay.Hours = new List<CalendarHour>();

                for (int hour = 9; hour <= 17; hour++)
                {
                    CalendarHour calendarHour = new CalendarHour();
                    calendarHour.Time = new TimeSpan(hour, 0, 0);
                    calendarHour.IsAvailable = true; // Set the availability as needed

                    calendarDay.Hours.Add(calendarHour);
                }

                bookingModel.Days.Add(calendarDay);
            }
            CurrentModel = bookingModel;
            return bookingModel;
        }

        public static void InitializeBookings()
        {
            // create a new random instance
            Random random = new Random();

            // get all July 2023 dates
            var dates = GetJuly2023Dates();

            // for each day in July 2023
            foreach (var day in dates.Days)
            {
                // for each hour of each day
                foreach (var hour in day.Hours)
                {
                    // 30% chance to book the hour
                    if (random.Next(100) < 30)
                    {
                        // book the date and time
                        BookDate(day.Date, hour.Time);
                    }
                }
            }
        }
    }
    public class Booking
    {
        public CalendarDay Day { get; set; }
        public CalendarHour Hour { get; set; }
    }
    
}