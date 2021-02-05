using System;
using System.Threading.Tasks;
using Microsoft.Graph;

namespace MicrosoftGraphApplicationAuth
{
    public class ExampleUsingGraph
    {
        private readonly IGraphServiceClientFactory _factory;

        public ExampleUsingGraph(IGraphServiceClientFactory factory)
        {
            _factory = factory;
        }

        public async Task<Event> CreateCalendarEvent(string userEmail)
        {
            IGraphServiceClient client = _factory.Create(new GraphConfig());
            var tomorrow = DateTime.Now.AddDays(1);
            Event newEvvent = new Event
            {
                Subject = "Dinner Party",
                Start = DateTimeTimeZone.FromDateTime(tomorrow),
                End = DateTimeTimeZone.FromDateTime(tomorrow.AddHours(1))
            };
            return await client.Users[userEmail].Calendar.Events.Request().AddAsync(newEvvent);
        }
    }
}