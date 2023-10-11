using Microsoft.EntityFrameworkCore;
using MovieRentalAppBE.Models;

namespace MovieRentalAppBE.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<RentDetail> RentDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure Customer entity
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customers");
                entity.HasKey(e => e.CustomerId);
                entity.Property(e => e.CustomerId).HasDefaultValueSql("NEWID()");
                entity.Property(e => e.Name).HasMaxLength(100).IsRequired().IsUnicode(false);
                entity.Property(e => e.Email).HasMaxLength(100).IsUnicode(false);
                entity.Property(e => e.Phone).HasMaxLength(20).IsUnicode(false);
                entity.Property(e => e.Address).HasMaxLength(200).IsUnicode(false);
            });

            // Configure Movie entity
            modelBuilder.Entity<Movie>(entity =>
            {
                entity.ToTable("Movies");
                entity.HasKey(e => e.MovieId);
                entity.Property(e => e.MovieId).HasDefaultValueSql("NEWID()");
                entity.Property(e => e.Title).HasMaxLength(100).IsRequired().IsUnicode(false);
                entity.Property(e => e.ReleaseYear).HasColumnName("ReleaseYear");
                entity.Property(e => e.Genre).HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.Rating).HasMaxLength(10).IsUnicode(false);
                entity.Property(e => e.RentalPrice).HasColumnType("decimal(5, 2)");
            });

            // Configure RentDetail entity
            modelBuilder.Entity<RentDetail>(entity =>
            {
                entity.ToTable("RentDetails");
                entity.HasKey(e => e.OrderId);
                entity.Property(e => e.OrderId).HasDefaultValueSql("NEWID()");
                entity.Property(e => e.CustomerId).HasColumnType("uniqueidentifier");
                entity.Property(e => e.MovieId).HasColumnType("uniqueidentifier");
                entity.Property(e => e.OrderDate).HasColumnType("datetime").HasColumnName("OrderDate").IsRequired(false);
            });


            base.OnModelCreating(modelBuilder);
        }
    }
}