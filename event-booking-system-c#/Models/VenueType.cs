using System.ComponentModel.DataAnnotations;

namespace event_booking_system_c_.Models
{
    public class VenueType
    {
        [Key]
        public int VenueTypeId { get; set; }

        [Required, MaxLength(100)]
        public string Title { get; set; } = null!;

        public ICollection<Venue> Venues { get; set; } = new HashSet<Venue>();

    }
}
