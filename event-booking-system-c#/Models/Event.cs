using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace event_booking_system_c_.Models
{
    public class Event
    {
        public int EventId { get; set; }

        public int ClientId { get; set; }
        public int VenueId { get; set; }
        public int EventTypeId { get; set; }

        [Required, MaxLength(150)]
        public string EventName { get; set; } = null!;

        public DateTime EventDate { get; set; }

        public string? Description { get; set; }
        [ForeignKey(nameof(ClientId))]
        public Client? Client { get; set; }

        [ForeignKey(nameof(VenueId))]
        public Venue? Venue { get; set; }

        [ForeignKey(nameof(EventTypeId))]
        public EventType? EventType { get; set; }

        public ICollection<Booking> Bookings { get; set; } = new HashSet<Booking>();

    }
}
