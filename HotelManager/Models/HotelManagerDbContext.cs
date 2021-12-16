using Microsoft.EntityFrameworkCore;

namespace HotelManager.Models
{
    public class HotelManagerDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HotelManagerDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
          
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().HasOne<Reservation>(s => s.Reservation).WithMany(g => g.Guests).HasForeignKey(s => s.CurrentReservatonId);
            modelBuilder.Entity<Reservation>().HasOne<Room>(r => r.Room).WithOne(ro => ro.Reservation).HasForeignKey<Room>(ro => ro.CurrentReservatonId);
        }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
    }
}
