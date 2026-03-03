using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace event_booking_system_c_.Models
{
    public class Venue
    {
        public int VenueId { get; set; }

        public int VenueTypeId { get; set; }

        [Required, MaxLength(150)]
        public string Name { get; set; } = null!;

        [Required, MaxLength(200)]
        public string Location { get; set; } = null!;

        public int Capacity { get; set; }

        [MaxLength(500)]
        public string? ImageUrl { get; set; }

        [ForeignKey(nameof(VenueTypeId))]
        public VenueType? VenueType { get; set; }
        public ICollection<Event> Events { get; set; } = new HashSet<Event>();
        public ICollection<Booking> Bookings { get; set; } = new HashSet<Booking>();


    }
}
