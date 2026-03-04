using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace event_booking_system_c_.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }

        public int EventId { get; set; }
        public int VenueId { get; set; }

        public DateTime BookingDate { get; set; } // DB default GETDATE() can be configured in DbContext Fluent API

        [ForeignKey(nameof(EventId))]
        public Event? Event { get; set; }

        [ForeignKey(nameof(VenueId))]
        public Venue? Venue { get; set; }
    }
}
