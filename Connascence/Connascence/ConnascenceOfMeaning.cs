using System;
using System.Collections.Generic;

namespace ConnascenceOfMeaning
{
    public class ScheduleItem
    {
        public string Flight { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTimeOffset DepartureDt { get; set; }
        public DateTimeOffset ArrivalDt { get; set; }
    }

    public class FlightBookingService
    {
        private static readonly Random _rand = new Random();

        public string BookFlight(string flight, DateTimeOffset departureDt)
        {
            if (_rand.NextDouble() > 0.95)
            {
                return "FAILURE";
            }

            return "SUCCESS";
        }
    }

    public class Itinerary
    {
        private readonly IList<ScheduleItem> _scheduleItems;

        public int BookItinerary()
        {
            var bookingService = new FlightBookingService();
            foreach (var scheduleItem in _scheduleItems)
            {
                var status = bookingService.BookFlight(
                    scheduleItem.Flight,
                    scheduleItem.DepartureDt);
                // Check if BookFlight completed successfully by
                // comparing retuned result against string value.
                if (status != "SUCCESS")
                {
                    return 1;
                }
            }
            return 0;
        }
    }
}