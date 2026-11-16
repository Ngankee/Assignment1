using Microsoft.AspNetCore.Mvc;
using Assignment1.Models;

namespace Assignment1.Controllers
{
    public class EventController : Controller
    {
        private static List<Event> events = new List<Event>
        {
            new Event
            {
                Id = 1,
                Title = "Career Fair",
                Date = new DateTime(2026, 2, 1),
                Location = "Gym"
            },

            new Event
            {
                Id = 2,
                Title = "Tech Talk",
                Date = new DateTime(2026, 2, 8),
                Location = "Auditorium"
            },

            new Event
            {
                Id = 3,
                Title = "Hack Night",
                Date = new DateTime(2026, 2, 15),
                Location = "Library"
            }
        };

        public IActionResult Index()
        {
            ViewData["Title"] = "Event Manager";
            return View(events);
        }

        // Opens page
        public IActionResult ManageAttendees(int id)
        {
            Event? selectedEvent = events.FirstOrDefault(e => e.Id == id);

            ViewData["Title"] = "Manage Attendees";

            return View(selectedEvent);
        }


        // Handles the submitted signup form
        [HttpPost]
        public IActionResult ManageAttendees(int id, string name, string email)
        {
            Event? selectedEvent = events.FirstOrDefault(e => e.Id == id);

            Attendee attendee = new Attendee
            {
                Name = name,
                Email = email
            };

            selectedEvent.Attendees.Add(attendee);

            return RedirectToAction("ManageAttendees", new { id = id });
        }
    }
}
