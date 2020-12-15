using DataServer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataServer.Persistence
{
    public class MapDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Report<User>> UserReports { get; set; }
        public DbSet<Place> Places { get; set; }

        public DbSet<Report<Place>> PlaceReports { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Report<Review>> ReviewReports { get; set; }

        public MapDbContext()
		{
            //Database.EnsureCreated();
		}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //name of database
            optionsBuilder.UseSqlite("Data Source = Map.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany(u => u.savedPlaces).WithMany(p => p.savedBy);
            modelBuilder.Entity<Place>().HasOne(p => p.addedBy);
            modelBuilder.Entity<Report<Place>>().HasOne(p => p.reportedItem);
            modelBuilder.Entity<Report<Review>>().HasOne(p => p.reportedItem);
            modelBuilder.Entity<Report<User>>().HasOne(p => p.reportedItem);
        }
    }
}