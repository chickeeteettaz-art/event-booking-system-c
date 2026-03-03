using System.ComponentModel.DataAnnotations;

namespace event_booking_system_c_.Models
{
    public class Client
    {
        public int ClientId { get; set; }

        [Required, MaxLength(150)]
        public string FullName { get; set; } = null!;

        [Required, MaxLength(150), EmailAddress]
        public string EmailAddress { get; set; } = null!;

        public ICollection<Event> Events { get; set; } = new HashSet<Event>();

    }
}
