using event_booking_system_c_.Models;
using Microsoft.EntityFrameworkCore;

namespace event_booking_system_c_.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<VenueType> VenuesTypes { get; set; }
        public DbSet<EventType> EventsTypes { get; set; }


    }
}
