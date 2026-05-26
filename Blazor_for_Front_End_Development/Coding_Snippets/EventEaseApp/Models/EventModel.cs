using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EventEaseApp.Models
{
    public class EventModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Event Name is required.")]
        [StringLength(50, ErrorMessage = "Name is too long (max 50 characters).")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Event Date is required.")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Location is required.")]
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