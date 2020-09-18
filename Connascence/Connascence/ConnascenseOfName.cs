using System;
using System.Collections.Generic;

namespace ConnascenceOfType
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
            // 1. We are referring properties here.
            //    If a property name chages, we have to change it
            //    in this line as well.
            return $"Flight {Flight} from {Origin} on {DepartureDt} to {Destination} on {ArrivalDt}";
        }
    }

    public class Itinerary
    {
        // 2. If we rename ScheduleItem class we will have to change
        //    the class name here to make code compilable.
        // 3. We may also need to change _scheduleItems field names
        //    to keep it consistent with the ScheduleItem class name.
        private readonly IList<ScheduleItem> _scheduleItems;

        public void Print()
        {
            foreach (var item in _scheduleItems)
            {
                // 4. If we change Print methond name, we will have to
                //    change it in this line as well.   
                Console.WriteLine(item.Print());
            }
        }
    }
}