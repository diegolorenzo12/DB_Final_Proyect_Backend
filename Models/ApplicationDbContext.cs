using Microsoft.EntityFrameworkCore;
using projecto_bases_de_datos_api.Models;

namespace projecto_bases_de_datos_api.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<ParkingSpot> ParkingSpots { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<ParkingSpotAssignment> ParkingSpotAssignments { get; set; }
        public DbSet<ParkingRecord> ParkingRecords { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options){
         }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure User entity
            modelBuilder.Entity<User>()
                .Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<User>()
                .HasMany(u => u.ParkingSpotAssignments)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserID);

            // Configure ParkingSpot entity
            modelBuilder.Entity<ParkingSpot>()
                .Property(p => p.Location)
                .IsRequired();

            modelBuilder.Entity<ParkingSpot>()
                .HasOne(p => p.Building)
                .WithMany(b => b.ParkingSpots)
                .HasForeignKey(p => p.BuildingID);

            // Configure Vehicle entity
            modelBuilder.Entity<Vehicle>()
                .Property(v => v.LicensePlate)
                .IsRequired();

            modelBuilder.Entity<Vehicle>()
                .HasOne(v => v.User)
                .WithMany(u => u.Vehicles)
                .HasForeignKey(v => v.UserID);

            // Configure Building entity
            modelBuilder.Entity<Building>()
                .Property(b => b.Name)
                .IsRequired();

            // Configure ParkingSpotAssignment entity
            modelBuilder.Entity<ParkingSpotAssignment>()
                .HasKey(psa => new { psa.ParkingSpotID, psa.UserID }); // Composite Key

            // Configure ParkingRecord entity
            modelBuilder.Entity<ParkingRecord>()
                .HasOne(pr => pr.ParkingSpot)
                .WithMany()
                .HasForeignKey(pr => pr.ParkingSpotID);

            modelBuilder.Entity<ParkingRecord>()
                .HasOne(pr => pr.User)
                .WithMany()
                .HasForeignKey(pr => pr.UserID);

            modelBuilder.Entity<ParkingRecord>()
                .HasOne(pr => pr.Vehicle)
                .WithMany()
                .HasForeignKey(pr => pr.VehicleID);
        }

    }
}
