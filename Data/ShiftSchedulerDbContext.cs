using Microsoft.EntityFrameworkCore;
using ShiftSchedulerApi.Models;

namespace ShiftSchedulerApi.Data
{
    public class ShiftSchedulerDbContext : DbContext
    {
        public ShiftSchedulerDbContext(DbContextOptions<ShiftSchedulerDbContext> options) : base(options)
        {

        }

            public DbSet<Shift> Shifts { get; set; }
            public DbSet<User> Users { get; set; }
            public DbSet<Team> Team { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<ShiftUser>()
                    .HasKey(su => new { su.ShiftId, su.UserId });
                modelBuilder.Entity<ShiftUser>()
                    .HasOne(su => su.Shift)
                    .WithMany(s => s.Attendees)
                    .HasForeignKey(su => su.ShiftId);
                modelBuilder.Entity<ShiftUser>().HasOne(su => su.User).WithMany(u => u.Shifts)
                    .HasForeignKey(su => su.UserId);
            }
    }
}
