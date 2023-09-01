using Microsoft.EntityFrameworkCore;
using Proiect_DezvoltareaAplicatiilorWeb.Models;

namespace Proiect_DezvoltareaAplicatiilorWeb.Data
{
    public class ProjectContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<MovieRental> MovieRentals { get; set; }

        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options) 
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(u => u.Address)
                .WithOne(a => a.User)
                .HasForeignKey<Address>(a => a.UserId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Rentals)
                .WithOne(r => r.User);

            modelBuilder.Entity<MovieRental>()
                .HasKey(mr => new {mr.MovieId, mr.RentalId});

            modelBuilder.Entity<MovieRental>()
                .HasOne(mr => mr.Movie)
                .WithMany(m => m.MoviesRentals)
                .HasForeignKey(mr => mr.MovieId);
            modelBuilder.Entity<MovieRental>()
                .HasOne(mr => mr.Rental)
                .WithMany(r => r.MoviesRentals)
                .HasForeignKey(mr => mr.RentalId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
