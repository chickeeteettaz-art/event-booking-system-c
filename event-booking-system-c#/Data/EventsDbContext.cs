using event_booking_system_c_.Models;
using Microsoft.EntityFrameworkCore;

namespace event_booking_system_c_.Data
{
    public class EventsDbContext : DbContext
    {
        public EventsDbContext(DbContextOptions<EventsDbContext> options) : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<VenueType> VenuesTypes { get; set; }
        public DbSet<EventType> EventsTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Client -> Events (Cascade delete)
            modelBuilder.Entity<Event>()
                .HasOne(e => e.Client)
                .WithMany(c => c.Events)
                .HasForeignKey(e => e.ClientId)
                .OnDelete(DeleteBehavior.Cascade);

            // Unique constraint for Client.EmailAddress
            modelBuilder.Entity<Client>()
                .HasIndex(c => c.EmailAddress)
                .IsUnique();

            // VenueType -> Venue (Cascade delete)
            modelBuilder.Entity<Venue>()
                .HasOne(v => v.VenueType)
                .WithMany(vt => vt.Venues)
                .HasForeignKey(v => v.VenueTypeId)
                .OnDelete(DeleteBehavior.Cascade);

            // EventType -> Event (No action on delete)
            modelBuilder.Entity<Event>()
                .HasOne(e => e.EventType)
                .WithMany(et => et.Events)
                .HasForeignKey(e => e.EventTypeId)
                .OnDelete(DeleteBehavior.NoAction);

            // Venue -> Event (No action on delete)
            modelBuilder.Entity<Event>()
                .HasOne(e => e.Venue)
                .WithMany(v => v.Events)
                .HasForeignKey(e => e.VenueId)
                .OnDelete(DeleteBehavior.NoAction);

            // Event -> Booking (Cascade delete)
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Event)
                .WithMany(e => e.Bookings)
                .HasForeignKey(b => b.EventId)
                .OnDelete(DeleteBehavior.Cascade);

            // Venue -> Booking (No action on delete)
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Venue)
                .WithMany(v => v.Bookings)
                .HasForeignKey(b => b.VenueId)
                .OnDelete(DeleteBehavior.NoAction);

            // BookingDate default value to GETDATE()
            modelBuilder.Entity<Booking>()
                .Property(b => b.BookingDate)
                .HasDefaultValueSql("GETDATE()");
        }
    }
}
