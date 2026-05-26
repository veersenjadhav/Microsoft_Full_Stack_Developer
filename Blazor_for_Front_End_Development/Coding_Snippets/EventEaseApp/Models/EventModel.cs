using System;
using System.Collections.Generic;

namespace EventEaseApp.Models
{
    public class EventModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }

        // Mock database for sharing state across pages
        public static List<EventModel> Events { get; set; } = new List<EventModel>
        {
            new EventModel { Id = 1, Name = "Annual Tech Conference", Date = DateTime.Today.AddDays(30), Location = "Convention Center" },
            new EventModel { Id = 2, Name = "Music Festival", Date = DateTime.Today.AddDays(45), Location = "City Park" },
            new EventModel { Id = 3, Name = "Art Expo", Date = DateTime.Today.AddDays(60), Location = "Downtown Gallery" }
        };
    }
}