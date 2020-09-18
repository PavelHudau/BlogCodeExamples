using System;
using System.Collections.Generic;
using System.Linq;

namespace ConnascenceOfTYpe
{
    public class ScheduleItem
    {
        public string Flight { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTimeOffset DepartureDt { get; set; }
        public DateTimeOffset ArrivalDt { get; set; }

        public string Print()
        {
            return $"Flight {Flight} from {Origin} on {DepartureDt} to {Destination} on {ArrivalDt}";
        }
    }

    public class Itinerary
    {
        private readonly IList<ScheduleItem> _scheduleItems;

        public string Print()
        {
            List<string> printedSchedules = new List<string>();
            foreach (var item in _scheduleItems)
            {
                // COMPILE ERROR
                // printedSchedules is a collection of strings, therefore we can not
                // add ScheduleItem instance into the collection.
                printedSchedules.Add(item);

                // FIXED
                // A fix is simple, developer just forgot to call Print() on item.
                // Print() returns a string that can be added to printedSchedules.
                printedSchedules.Add(item.Print());
            }

            return string.Join(Environment.NewLine, printedSchedules);
        }
    }
}