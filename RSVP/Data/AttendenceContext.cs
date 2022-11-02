using Microsoft.EntityFrameworkCore;
using RSVP.Entities;

namespace RSVP.Data
{
    public class AttendenceContext : DbContext
    {
        public AttendenceContext(DbContextOptions<AttendenceContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(x => x.Attendence)
                .HasConversion<string>();

        }
    }
}
