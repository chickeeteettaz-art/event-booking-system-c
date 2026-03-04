using System.ComponentModel.DataAnnotations;

namespace event_booking_system_c_.Models
{
    public class EventType
    {
        [Key]
        public int EventTypeId { get; set; }

        [Required, MaxLength(100)]
        public string Title { get; set; } = null!;

        public ICollection<Event> Events { get; set; } = new HashSet<Event>();

    }
}
