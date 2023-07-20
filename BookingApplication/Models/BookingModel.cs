using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BookingApplication.Models
{
    public class BookingModel
    {
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

        public class CalendarDay
        {
            public DateTime Date { get; set; }
            public List<CalendarHour> Hours { get; set; }
        }
        public class CalendarHour
        {
            public TimeSpan Time { get; set; }
            public bool IsAvailable { get; set; }
        }

        public static BookingBrowseModel GetJuly2023Dates()
        {
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

            return bookingModel;
        }
    }
}